    public class TreeNode
    {
        public string text { get; set; }
        public bool leaf { get; set; }
        public bool expanded { get; set; }
        public List<TreeNode> children { get; set; }
        public TreeNode()
        {
            leaf = false;
            expanded = true;
            children = new List<TreeNode>();
        }
    }
