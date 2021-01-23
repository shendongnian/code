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
    }
