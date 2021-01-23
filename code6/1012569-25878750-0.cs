    string stringToSearch = radTextBoxSearch.Text.ToLower();
    treeView.SuspendLayout();
    foreach (RadTreeNode node in treeView.Nodes)
    {
        string nodeText = node.Text.ToLower();
        node.Visible = nodeText.StartsWith(stringToSearch);
    }
    treeView.ResumeLayout();
