    List<TreeNode> treeNodeList = new List<TreeNode>();
                treeNodeList.Add(new TreeNode
                {
                    text = "Invisible",
                    expanded = true,
                    leaf = false
                });
                treeNodeList.Add(new TreeNode
                {
                    text = "Visible",
                    expanded = true,
                    leaf = false
                });
    
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        treeNodeList[0].children.Add(new TreeNode
                                            {
                                                text = ds.Tables[0].Rows[i][0].ToString(),
                                                leaf = true
                                            });
                    }
                }
    
                if (ds.Tables.Count > 1)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        treeNodeList[1].children.Add(new TreeNode
                        {
                            text = ds.Tables[1].Rows[i][0].ToString(),
                            leaf = true
                        });
                    }
                }
                return treeNodeList;
