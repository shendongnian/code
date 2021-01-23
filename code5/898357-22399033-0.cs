    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            foreach (TreeNode ParentNodes in TreeView1.Nodes)
            {
                ParentNodes.Text = ParentNodes.Text.Replace("<b>", "").Replace("</b>", "");
                foreach (TreeNode ChildNodes in ParentNodes.ChildNodes)
                {
                    ChildNodes.Text = ChildNodes.Text.Replace("<b>", "").Replace("</b>", "");
                }
            }
            TreeNode node = TreeView1.SelectedNode;
            node.Text = Server.HtmlDecode("<b>" + node.Text + "</b>");
            node.Parent.Text = Server.HtmlDecode("<b>" + node.Parent.Text + "</b>");
        }
    }
