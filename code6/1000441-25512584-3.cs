        SampleDataTable = new DataTable();
        //Insert sample data to this table
        treeView1.Nodes.Clear();
        foreach (DataRow dr in SampleDataTable.Rows)
        {
            if ((Int)dr["ParentNodeID"] == 0)
            {
                TreeNode parentNode = new TreeNode();
                parentNode .Text = dr["NodeName"].ToString();
                string value = dr["NodeID"].ToString();
                treeView1.Nodes.Add(parentNode);
                findNode(parentNode, value);
            }
        }
    public void findNode(TreeNode parent, string Id)
    {
        IEnumerable<DataRow> rows = SampleDataTable.Select("ParentNodeID=" + Id);
        foreach (DataRow dr in rows)
        {
            //Create child node
            TreeNode child = new TreeNode();
            child.Text = dr["NodeName"].ToString().Trim();
            parent.Nodes.Add(child);
            //Add more child nodes recursively
            findNode(child, dr["NodeID"].ToString());
        }
    }
