    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.Equals("Node1"))
            {
                DisableHide(true);
            }
            else
            {
                DisableHide(false);
            }
        }
        private void DisableHide(bool state)
        {
            menuItem1.Enabled = state;
        }
