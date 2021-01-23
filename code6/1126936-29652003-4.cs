        /// <summary>
        /// All treeviews fire this event when a node's checkbox is check/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Any node that is checked/unchecked will have all of its 
            // children nodes checked/unchecked
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode childNode in e.Node.Nodes)
                {
                    childNode.Checked = e.Node.Checked;
                }
            }
            // Now it doesn't matter which treeview we are working with, let's build the rowFilter
            // with all three treeviews
            string areaCodeRowFilter = string.Empty;
            // The order in which we use the treeviews is not important
            foreach (TreeNode node in treeView1.Nodes)
            {
                // treeView1 in this case is AreaCode
                // The foreach is going through all root nodes and we have to 
                //  traverse into the children nodes
                if (node.Nodes.Count > 0)
                {
                    // Iterate through the children nodes to start building the rowFilter string
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            if (areaCodeRowFilter.Length > 0)
                            {
                                areaCodeRowFilter += " OR ";
                            }
                            areaCodeRowFilter += "[AreaCode] = " + childNode.Text;
                        }
                    }
                }
            } // End foreach using treeView1 (AreaCode)
            // Do the same thing with the other treeViews
            // The order in which we use the treeviews is not important
            string landRowFilter = string.Empty;
            foreach (TreeNode node in treeView2.Nodes)
            {
                // Since these values are strings,
                // they have to be wrapped in single quotes.
                // Example, [Land] = 'North' OR [Land] = 'West'
                // treeView2 in this case is Land
                // The foreach is going through all root nodes and we have to 
                // traverse into the children nodes
                if (node.Nodes.Count > 0)
                {
                    // Iterate through the children nodes to start building the rowFilter string
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            if (landRowFilter.Length > 0)
                            {
                                landRowFilter += " OR ";
                            }
                            landRowFilter += "[Land] = '" + childNode.Text + "'";
                        }
                    }
                }
            } // End foreach using treeView2 (Land)
            string grantRowFilter = string.Empty;
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            if (grantRowFilter.Length > 0)
                            {
                                grantRowFilter += " OR ";
                            }
                            grantRowFilter += "[Grant] = '" + childNode.Text + "'";
                        }
                    }
                }
            } // End foreach using treeView3 (Grant)
            // We have three rowFilter strings that we have to concantenate and set into the DataView.RowFilter
            // How will you use these filters as an AND or an OR?
            // I will use them as an AND.  I will also wrap each part 
            // of the rowFilter string in parenthesis.  
            string rowFilter = string.Empty;
            if (areaCodeRowFilter.Length > 0)
            {
                areaCodeRowFilter = "(" + areaCodeRowFilter + ")";
                rowFilter = areaCodeRowFilter;
            }
            if (landRowFilter.Length > 0)
            {
                landRowFilter = "(" + landRowFilter + ")";
                if (rowFilter.Length > 0)
                {
                    rowFilter += " AND " + landRowFilter;
                }
                else
                {
                    rowFilter = landRowFilter;
                }
            }
            if (grantRowFilter.Length > 0)
            {
                grantRowFilter = "(" + grantRowFilter + ")";
                if (rowFilter.Length > 0)
                {
                    rowFilter += " AND " + grantRowFilter;
                }
                else
                {
                    rowFilter = grantRowFilter;
                }
            }
            MessageBox.Show(rowFilter);
            // Take out the MessageBox.Show, I've only got it here to show you 
            // how the string looks when it's built
            // Apply rowFilter to your DataView.RowFilter
        }
