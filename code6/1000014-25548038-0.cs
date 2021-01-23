    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                     if (busy) return;
                    busy = true;
                    try
                    {
                        TreeNode _node = e.Node;
                        
                        checkNodes(e.Node, e.Node.Checked);
                        if (e.Node.Checked)
                        {
                            MessageBox.Show(e.Node.Text);
                        }
                    }
                    
                   
                    finally
                    {
                        busy = false;
                    }
                }
    
            }
