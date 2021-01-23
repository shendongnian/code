    private string GetArrayofCheckedNodes()
    {
        return string.Join(" , ", GetCheckedNodes(TreeView1.Nodes));
    }
    public List<string> GetCheckedNodes(TreeNode parent)
    {
        List<string> nodes = new List<string>();
        if (parent.Checked)
        {
            nodes.Add(parent.Text);
        }
        if (parent.Nodes != null)
        {
            foreach (TreeNode childNode in parent.Nodes)
            {
                nodes.AddRange(GetCheckedNodes(childNode));
            }
        }
        return nodes;
    }
