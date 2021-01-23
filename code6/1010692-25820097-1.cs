     foreach (TreeNode childNode in tvCategories.Nodes)
                {
                    foreach (TreeNode child in childNode.ChildNodes)
                    {
                        string aa = child.Value;
                        if (child.Checked == true)
                        {
                            Label1.Text += "Checked Node :" + child.Value + " <br />";
                        }
                        else
                        {
                            Label1.Text += "UnChecked Node :" + child.Value + " <br />";
                        }
                    }
    
                    
                }
