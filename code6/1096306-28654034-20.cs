    public class TreeNode3 : TreeNode
    {
        public string Label { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        public bool Check3 { get; set; }
        public new string Text
        {
            get { return Label; }
            set { Label = value; base.Text = ""; }
        }
        public TreeNode3()   { }
        public TreeNode3(string text)   { Label = text; }
        public TreeNode3(string text, bool check1, bool check2, bool check3)
        {
            Label = text;
            Check1 = check1; Check2 = check2; Check3 = check3;
        }
        public TreeNode3(string text, TreeNode3[] children)
        {
            Label = text;
            foreach (TreeNode3 node in children) this.Nodes.Add(node);
        }
    }
