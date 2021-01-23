    public class TreeData
    {
        public TreeData Parent { get; private set; }
        public string ID { get; private set; }
        public List<TreeData> Child { get; private set; }
        //Constructor for root objects
        public TreeData(string id) : this(null, id)
        {
        }
        //Constructor for child objects
        public TreeData(TreeData parent, string id)
        {
            this.ID = id;
            this.Parent = parent;
            this.Child = new List<TreeData>();
        }
        public void Add(string childID)
        {
            this.Child.Add(new TreeData(this, childID));
        }
    }
