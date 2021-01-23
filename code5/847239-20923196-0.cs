    public class TreeData
    {
        private TreeData _child;
        public string Name { get; set; }
        public TreeData Next
        {
            get { return _child; }
            set { _child = value; }
        }
    }
    TreeData myTree = new TreeData("root");
    TreeData child1 = new TreeData("child1");
    TreeData child2 = new TreeData("child2");
    myTree.Next = child1;
    child1.Next = child2;
