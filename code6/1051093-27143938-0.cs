    class MyNode: TreeNode
    {
        public string AnotherName { get; set; }
        public int Id{ get; set; }
        public MyNewObjectType NewObject{ get; set; }
        .
        .
    }
    Tree.Nodes.Add(MyNode);
