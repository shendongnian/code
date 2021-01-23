    class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.data = data;
            right = null;
            left = null;
        }
    }
    class BinaryTree
    {
        Node root;       
        public BinaryTree()
        {
            root = null;
        }
        public void display(Node level)
        {
            Node current = level;
            if (current.left != null)
            {
                display(current.left);              
            }
            Console.WriteLine(current.data);
            if(current.right!=null)
            {
                display(current.right);                
            }
        }
        Queue<Node> qu = new Queue<Node>();
        public void LevelOrderTraversal()
        {
            while (true)
            {
                if (qu.Count == 0)
                { return; }
                else
                {
                    Node current = qu.Dequeue();
                    Console.WriteLine(current.data);
                    if (current.left != null)
                        qu.Enqueue(current.left);
                    if (current.right != null)
                        qu.Enqueue(current.right);
                }
            }
        }
        public void insert(int num)
        {
            Node newnode = new Node(num);
            Node currentNode;
            if(root==null)
            {
                root = newnode;
            }
            else 
            {
                currentNode=root;
                while(true)
                {
                    Node tmpParent = currentNode;
                    if(newnode.data<=currentNode.data)
                    {
                        currentNode = currentNode.left;
                        if (currentNode == null)
                        { tmpParent.left = newnode; return; }
                    }
                    else if(newnode.data>currentNode.data)
                    {
                        currentNode = currentNode.right;
                        if (currentNode == null)
                        { tmpParent.right = newnode; return; }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            BinaryTree bTree = new BinaryTree();
            bTree.root = new Node(50);
            bTree.root.left = new Node(25);
            bTree.root.right = new Node(75);
            bTree.insert(22);
            bTree.insert(78);
            bTree.qu.Enqueue(bTree.root);
            bTree.LevelOrderTraversal();
            Console.ReadLine();
        }
        
    }
