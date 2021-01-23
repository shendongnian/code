    protected void PopulateTreeView(TreeNodeCollection parentNode, string parentID, DataTable folders)
    {
        foreach (DataRow folder in folders.Rows)
        {
            if (folder["Attached to"] == parentID)
            {
                String key = folder["code"].ToString();
                String text = folder["description"].ToString();
                TreeNodeCollection newParentNode = parentNode.Add(key, text).Nodes;
                PopulateTreeView(newParentNode, folder["code"].ToString(), folders);
            }
        }
    }
