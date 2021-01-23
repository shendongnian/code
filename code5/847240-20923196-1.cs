    public class TreeData
    {
        private TreeData _parent;
        private List<TreeData> childs = new List<TreeData>(); 
        public TreeData(string name)
        {
            Name = name;
        }
        public void AddChild(TreeData child)
        {
            child.Parent = this;
            childs.Add(child);
        }
        public string Name { get; set; }
        public TreeData Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        public List<TreeData> Childs
        {
            get { return childs; }
        } 
    }
