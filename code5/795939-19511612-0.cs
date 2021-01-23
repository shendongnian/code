  		    if (arb.Rows.Count > 0)
            {
			    TreeNode MainNode = new TreeNode();
				
                string otPadre = arb.Rows[0][0].ToString();
                int nivel = 0;
				MainNode.Text = otPadre;
                trvOTHs.Nodes.Add(MainNode);
                for (int i = 0; i < arbolSub.Rows.Count; i++)
                {        
				
                TreeNode child = new TreeNode();
                child.Text = row["OT Hija"].ToString();
                if (arbolSub.Rows[i]["OT Padre"].ToString() == otPadre)
                {
                    MainNode.Nodes.Add(child);  
                }
                else
                {
                    FindParent(MainNode, row["OT Padre"].ToString(), child);
                }
				
                }
				
                trvOTHs.ExpandAll();
            }
