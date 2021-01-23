            private void ListNodes(TreeNode node, string root)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (TreeNode n in node.Nodes)
                    {
                        ListNodes(n, root + node.Text);
                    }
                }
                else
                {
                    Console.Write(" " + root + node.Text);
                }
            }
