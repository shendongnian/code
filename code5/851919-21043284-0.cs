    if (ds.Tables.Count > 0)
        {
            TreeNode root= new TreeNode("Root Node");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["Name"].ToString());
                
                root.ChildNodes.Add(NewNode);
            }
        }
    
