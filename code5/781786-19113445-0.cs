    DataSet ds = RunQuery("select PatientId,firstname from PatientDetails");
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
	TreeNode root = new TreeNode(ds.Tables[0].Rows[i]["ID"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString());
	root.SelectAction = TreeNodeSelectAction.Expand;
	TreeNode child = new TreeNode(ds.Tables[0].Rows[i]["ID"].ToString(), ds.Tables[0].Rows[i]["FirstName"].ToString());
	root.ChildNodes.Add(child);
	TVPatArc.Nodes.Add(root);
    }
