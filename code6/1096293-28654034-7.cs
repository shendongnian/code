    class TreeNode3 : TreeNode
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
        public TreeNode3 AddNode(string label, string name, 
                                 bool check1, bool check2, bool check3, object tag)
        {
            TreeNode3 node = new TreeNode3();
            node.Check1 = check1;
            node.Check2 = check2;
            node.Check3 = check3;
            node.Label = label;
            node.Name = name;
            node.Tag = tag;
            this.Nodes.Add(node);
            return node;
        }
    }
