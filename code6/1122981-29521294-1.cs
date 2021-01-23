     class MainProgram2
    {
        static void Main()
        {
            Tree theTree = new Tree();
            Console.WriteLine("Please Enter the string you want to process:"); // Prompt for total number of rovers
            string input = Console.ReadLine();
            foreach (char c in input)
            {
                // Check if it's a digit or not
                if (c >= '0' && c <= '9')
                {
                    theTree.Insert((int)Char.GetNumericValue(c));
                }
            }
            //End of for each (char c in input)
            Console.WriteLine("Inorder traversal resulting Tree Sort without the zeros");
            theTree.Inorder(theTree.ReturnRoot());
            Console.WriteLine(" ");
            //Format the output depending on how many zeros you have
            Console.WriteLine("The final 3 digits are");
            switch (theTree.ZeroDigitsList.Count)
            {
                case 0:
                    {
                        Console.WriteLine("{0}{1}{2}", theTree.SortedDigitsList[0], theTree.SortedDigitsList[1], theTree.SortedDigitsList[2]);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("{0}{1}{2}", theTree.SortedDigitsList[0], 0, theTree.SortedDigitsList[2]);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("{0}{1}{2}", theTree.SortedDigitsList[0], 0, 0);
                        break;
                    }
            }
            Console.ReadLine();
        }
    }//End of main()
     }
    
    class Node
    {
        public int item;
        public Node leftChild;
        public Node rightChild;
        public void displayNode()
        {
            Console.Write("[");
            Console.Write(item);
            Console.Write("]");
        }
    }
    class Tree 
    {
    public List<int> SortedDigitsList { get; set; }
    public List<int> ZeroDigitsList { get; set; }
    public Node root;
    public Tree()
    {
        root = null;
        SortedDigitsList = new List<int>();
        ZeroDigitsList = new List<int>();
    }
    public Node ReturnRoot()
    {
        return root;
    }
    public void Insert(int id)
    {
        Node newNode = new Node();
        newNode.item = id;
        if (root == null)
            root = newNode;
        else
        {
            Node current = root;
            Node parent;
            while (true)
            {
                parent = current;
                if (id < current.item)
                {
                    current = current.leftChild;
                    if (current == null)
                    {
                        parent.leftChild = newNode;
                        return;
                    }
                }
                else
                {
                    current = current.rightChild;
                    if (current == null)
                    {
                        parent.rightChild = newNode;
                        return;
                    }
                }
            }
        }
    }
    //public void Preorder(Node Root)
    //{
    //    if (Root != null)
    //    {
    //        Console.Write(Root.item + " ");
    //        Preorder(Root.leftChild);
    //        Preorder(Root.rightChild);
    //    }
    //}
    public void Inorder(Node Root)
    {
        if (Root != null)
        {
            Inorder(Root.leftChild);
            if (Root.item > 0)
            {
                SortedDigitsList.Add(Root.item);
                Console.Write(Root.item + " ");
            }
            else
            {
                ZeroDigitsList.Add(Root.item);
            }
            Inorder(Root.rightChild);
        }
    }
