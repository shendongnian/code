                if (e.Node.Nodes.Count >= 1)
                {
                    if (tvFileMan.SelectedNode != null)
                    {
                        tvFileMan.SelectedNode.Checked = false;
                        foreach (TreeNode tn in tvFileMan.SelectedNode.Nodes)
                        {
                            if (tn.Nodes.Count.Equals(0))
                                tn.Checked = false;
                        }
                    }
                }
