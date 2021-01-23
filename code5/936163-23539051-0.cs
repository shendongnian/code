        private void machinesTreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            for (int w = 0; w < machinesTreeView.SelectedNode.Nodes.Count; w++)
            {
                machinesTreeView.SelectedNode.Nodes[w].Selected = true;
            }
        }
