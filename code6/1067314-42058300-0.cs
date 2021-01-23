    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public int Data { get; set; }
        public TreeNode Right { get; set; }
        
        public TreeNode(int data)
        {
            this.Left = null;
            this.Data = data;
            this.Right = null;
        }
    }
    public class DLLNode
    {
        public DLLNode Prev { get; set; }
        public int Data { get; set; }
        public DLLNode Next { get; set; }
        
        public DLLNode(int data)
        {
            this.Data = data;
        }
    }
    public class Tree
    {
        public TreeNode Root { get; set; }
        public Tree()
        {
            // Creating a dummy tree;
            Root = new TreeNode(10);
            Root.Left = new TreeNode(12);
            Root.Left.Left = new TreeNode(25);
            Root.Left.Right = new TreeNode(30);
            Root.Right = new TreeNode(15);
            Root.Right.Left = new TreeNode(36);
        }
    }
    public class DLL
    {
        private DLLNode Curr { get; set; }
        public DLLNode Head { get; set; }
        
        public void FromTree(Tree t)
        {
            ProcessInOrder(t.Root);
        }
        public void Display()
        {
            while(Head != null)
            {
                Console.Write(Head.Data + ", ");
                Head = Head.Next;
            }
        }
        
        private void ProcessInOrder(TreeNode n)
        {
            if(n != null)
            {
                ProcessInOrder(n.Left);
                CreateDLLNode(n);
                ProcessInOrder(n.Right);
            }        
        }
        private void CreateDLLNode(TreeNode n)
        {
            DLLNode node = new DLLNode(n.Data);
            if(Curr == null)
            {
                Curr = Head = node;
            }
            else
            {
                Curr.Next = node;
                node.Prev = Curr;
                Curr = node;
            }
        }
    }
    DLL d = new DLL();
    d.FromTree(new Tree());
    d.Display();
