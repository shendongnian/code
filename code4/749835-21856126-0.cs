                if (treeView.Enabled) {
                    treeView.AfterCheck -= tw_AfterCheck;
                    TreeNode node = e.Node;
                    if (node.Nodes != null) 
                        node.Nodes.Cast<TreeNode>().ToList().ForEach(v => v.Checked = node.Checked);
                    node = e.Node.Parent;
                    while (node != null) {
                        bool set = e.Node.Checked
                                   ? node.Nodes.Cast<TreeNode>()
                                    .Any(v => v.Checked == e.Node.Checked)
                                   : node.Nodes.Cast<TreeNode>()
                                    .All(v => v.Checked == e.Node.Checked);
                        if (set) {
                            node.Checked = e.Node.Checked;
                            node = node.Parent;
                        }
                        else
                            node = null;
                    }
                   treeView.AfterCheck += tw_AfterCheck;
                }
            }
