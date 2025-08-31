namespace DataStructure_Algorithm
{
    using System;
    using System.Collections.Generic;

    class DSAProgram
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n==== DSA MENU ====");
                Console.WriteLine("1. Array Operations");
                Console.WriteLine("2. String Operations");
                Console.WriteLine("3. Stack Demo");
                Console.WriteLine("4. Queue Demo");
                Console.WriteLine("5. Linked List Demo");
                Console.WriteLine("6. Hashing (Char Frequency)");
                Console.WriteLine("7. Searching (Linear & Binary)");
                Console.WriteLine("8. Sorting Algorithms");
                Console.WriteLine("9. Recursion (Factorial/Fibonacci)");
                Console.WriteLine("10. Binary Tree Traversals");
                Console.WriteLine("11. Graph (BFS & DFS)");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: ArrayOperations(); break;
                    case 2: StringOperations(); break;
                    case 3: StackDemo(); break;
                    case 4: QueueDemo(); break;
                    case 5: LinkedListDemo(); break;
                    case 6: HashingDemo(); break;
                    case 7: SearchingDemo(); break;
                    case 8: SortingDemo(); break;
                    case 9: RecursionDemo(); break;
                    case 10: BinaryTreeDemo(); break;
                    case 11: GraphDemo(); break;
                    case 0: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        // ------------------ ARRAYS ------------------
        static void ArrayOperations()
        {
            int[] arr = { 5, 3, 7, 3, 2, 7 };
            Console.WriteLine("\nOriginal Array: " + string.Join(", ", arr));

            // Bubble Sort
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

            Console.WriteLine("Sorted Asc: " + string.Join(", ", arr));
            Console.WriteLine("Min: " + arr[0] + ", Max: " + arr[arr.Length - 1]);

            Console.Write("Duplicates: ");
            bool hasDup = false;
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] == arr[i + 1] && (i == 0 || arr[i] != arr[i - 1]))
                {
                    Console.Write(arr[i] + " ");
                    hasDup = true;
                }
            if (!hasDup) Console.Write("None");
            Console.WriteLine();
        }

        // ------------------ STRINGS ------------------
        static void StringOperations()
        {
            string str = "banana";
            Console.WriteLine("\nString: " + str);

            // Reverse
            char[] ch = str.ToCharArray();
            Array.Reverse(ch);
            Console.WriteLine("Reversed: " + new string(ch));

            // Palindrome
            Console.WriteLine("Is Palindrome? " + (str == new string(ch)));

            // Max occurrence char
            int[] freq = new int[256];
            foreach (char c in str) freq[c]++;
            int maxCount = 0; char maxChar = '\0';
            for (int i = 0; i < 256; i++)
                if (freq[i] > maxCount) { maxCount = freq[i]; maxChar = (char)i; }
            Console.WriteLine($"Max Occurrence: '{maxChar}' => {maxCount}");
        }

        // ------------------ STACK ------------------
        static void StackDemo()
        {
            Stack<int> st = new Stack<int>();
            st.Push(10); st.Push(20); st.Push(30);
            Console.WriteLine("\nStack: " + string.Join(", ", st));
            Console.WriteLine("Pop: " + st.Pop());
            Console.WriteLine("Peek: " + st.Peek());
        }

        // ------------------ QUEUE ------------------
        static void QueueDemo()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1); q.Enqueue(2); q.Enqueue(3);
            Console.WriteLine("\nQueue: " + string.Join(", ", q));
            Console.WriteLine("Dequeue: " + q.Dequeue());
            Console.WriteLine("Front: " + q.Peek());
        }

        // ------------------ LINKED LIST ------------------
        class Node { public int data; public Node next; public Node(int d) { data = d; } }
        static void LinkedListDemo()
        {
            Node head = new Node(10);
            head.next = new Node(20);
            head.next.next = new Node(30);

            Console.Write("\nLinked List: ");
            Node temp = head;
            while (temp != null) { Console.Write(temp.data + " "); temp = temp.next; }
            Console.WriteLine();
        }

        // ------------------ HASHING ------------------
        static void HashingDemo()
        {
            string str = "abracadabra";
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (dict.ContainsKey(c)) dict[c]++;
                else dict[c] = 1;
            }
            Console.WriteLine("\nChar Frequency in 'abracadabra':");
            foreach (var kv in dict) Console.WriteLine($"{kv.Key} => {kv.Value}");
        }

        // ------------------ SEARCHING ------------------
        static void SearchingDemo()
        {
            int[] arr = { 1, 3, 5, 7, 9, 11 };
            int key = 7;

            // Linear
            int pos = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == key) { pos = i; break; }
            Console.WriteLine($"\nLinear Search: {key} at index {pos}");

            // Binary
            int low = 0, high = arr.Length - 1;
            pos = -1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == key) { pos = mid; break; }
                else if (arr[mid] < key) low = mid + 1;
                else high = mid - 1;
            }
            Console.WriteLine($"Binary Search: {key} at index {pos}");
        }

        // ------------------ SORTING ------------------
        static void SortingDemo()
        {
            int[] arr = { 64, 25, 12, 22, 11 };
            Console.WriteLine("\nOriginal Array: " + string.Join(", ", arr));

            // Selection Sort
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[min]) min = j;
                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
            Console.WriteLine("Selection Sort: " + string.Join(", ", arr));
        }

        // ------------------ RECURSION ------------------
        static void RecursionDemo()
        {
            Console.WriteLine("\nFactorial(5): " + Factorial(5));
            Console.WriteLine("Fibonacci(7): " + Fibonacci(7));
        }
        static int Factorial(int n) => (n <= 1) ? 1 : n * Factorial(n - 1);
        static int Fibonacci(int n) => (n <= 1) ? n : Fibonacci(n - 1) + Fibonacci(n - 2);

        // ------------------ BINARY TREE ------------------
        class TreeNode
        {
            public int data;
            public TreeNode left, right;
            public TreeNode(int val) { data = val; }
        }

        static void BinaryTreeDemo()
        {
            // Sample Tree
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            Console.Write("\nInorder Traversal: ");
            Inorder(root);
            Console.Write("\nPreorder Traversal: ");
            Preorder(root);
            Console.Write("\nPostorder Traversal: ");
            Postorder(root);
            Console.Write("\nLevel-order Traversal: ");
            LevelOrder(root);
            Console.WriteLine();
        }

        static void Inorder(TreeNode root)
        {
            if (root == null) return;
            Inorder(root.left);
            Console.Write(root.data + " ");
            Inorder(root.right);
        }

        static void Preorder(TreeNode root)
        {
            if (root == null) return;
            Console.Write(root.data + " ");
            Preorder(root.left);
            Preorder(root.right);
        }

        static void Postorder(TreeNode root)
        {
            if (root == null) return;
            Postorder(root.left);
            Postorder(root.right);
            Console.Write(root.data + " ");
        }

        static void LevelOrder(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode temp = q.Dequeue();
                Console.Write(temp.data + " ");
                if (temp.left != null) q.Enqueue(temp.left);
                if (temp.right != null) q.Enqueue(temp.right);
            }
        }

        // ------------------ GRAPH ------------------
        static void GraphDemo()
        {
            int vertices = 5;
            List<int>[] graph = new List<int>[vertices];
            for (int i = 0; i < vertices; i++) graph[i] = new List<int>();

            // Sample edges (undirected graph)
            AddEdge(graph, 0, 1);
            AddEdge(graph, 0, 4);
            AddEdge(graph, 1, 2);
            AddEdge(graph, 1, 3);
            AddEdge(graph, 1, 4);
            AddEdge(graph, 2, 3);
            AddEdge(graph, 3, 4);

            Console.Write("\nBFS Traversal from 0: ");
            BFS(graph, 0, vertices);

            Console.Write("\nDFS Traversal from 0: ");
            bool[] visited = new bool[vertices];
            DFS(graph, 0, visited);
            Console.WriteLine();
        }

        static void AddEdge(List<int>[] graph, int u, int v)
        {
            graph[u].Add(v);
            graph[v].Add(u); // undirected
        }

        static void BFS(List<int>[] graph, int start, int vertices)
        {
            bool[] visited = new bool[vertices];
            Queue<int> q = new Queue<int>();
            visited[start] = true;
            q.Enqueue(start);

            while (q.Count > 0)
            {
                int node = q.Dequeue();
                Console.Write(node + " ");
                foreach (int nei in graph[node])
                    if (!visited[nei])
                    {
                        visited[nei] = true;
                        q.Enqueue(nei);
                    }
            }
        }

        static void DFS(List<int>[] graph, int node, bool[] visited)
        {
            visited[node] = true;
            Console.Write(node + " ");
            foreach (int nei in graph[node])
                if (!visited[nei])
                    DFS(graph, nei, visited);
        }
    }

}
