    private string GetArrayofCheckedNodes()
    {
        return string.Join(" , ", GetCheckedNodes(treeView1.Nodes));
    }
    public List<string> GetCheckedNodes(TreeNodeCollection nodes)
    {
        List<string> nodeList = new List<string>();
        if (nodes == null)
        {
            return nodeList;
        }
        foreach (TreeNode childNode in nodes)
        {
            if (childNode.Checked)
            {
                nodeList.Add(childNode.Text);
            }
            nodeList.AddRange(GetCheckedNodes(childNode.Nodes));
        }
        return nodeList;
    }
