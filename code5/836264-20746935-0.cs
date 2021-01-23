    DataRow root = myDataTable.Rows[0];
    treeView.Nodes.Add(root["ID"].ToString(), root["Name"].ToString());
    
    for (int i = 1; i < table.Rows.Count; i++)
    {
        DataRow parentRow = myDataTable.Rows.Find(myDataTable.Rows[i]["ParentID"]);
        TreeNode[] parent = treeView.Nodes.Find(parentRow["ID"].ToString(), true);
        parent[0].Nodes.Add(myDataTable.Rows[i]["ID"].ToString(), myDataTable.Rows[i]["Name"].ToString());
    }
