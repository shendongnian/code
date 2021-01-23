    public class ParentNode
    {
        public ParentNode() { }
        public string ParentNodeName { get; set; }
        public ObservableCollection<SubNode> AddChildNodes { get; set; }
        public ObservableCollection<CheckBoxSubNode> AddCheckBoxChildNodes { get; set; }
    }
    public class SubNode
    {
        public SubNode() { }
        public String SubNodeName { get; set; }
    }
    new ParentNode() { 
     parentnodename = "parent"
     addchildnodes = new SubNode() { Subnodename = "subnode" }
    )
