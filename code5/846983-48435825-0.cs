    private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
    {
        DoDragDrop(e.Item, DragDropEffects.Move);
    }
    
    private void treeView1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    }
    private void treeView1_DragDrop(object sender, DragEventArgs e)
    {
        // Retrieve the client coordinates of the drop location.
        Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
    
        // Retrieve the node at the drop location.
        TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
    
        // Retrieve the node that was dragged.
        TreeNode draggedNode = e.Data.GetData(typeof(TreeNode));
        // Sanity check
        if (draggedNode == null)
        {
            return;
        }
        // Did the user drop on a valid target node?
        if (targetNode == null)
        {
            // The user dropped the node on the treeview control instead
            // of another node so lets place the node at the bottom of the tree.
            draggedNode.Remove();
            treeView1.Nodes.Add(draggedNode);
            draggedNode.Expand();
        }
        else
        {
            TreeNode parentNode = targetNode;
            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (!draggedNode.Equals(targetNode) && targetNode != null)
            {
                bool canDrop = true;
                // Crawl our way up from the node we dropped on to find out if
                // if the target node is our parent. 
                while (canDrop && (parentNode != null))
                {
                    canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                    parentNode = parentNode.Parent;
                }
    
                // Is this a valid drop location?
                if (canDrop)
                {
                    // Yes. Move the node, expand it, and select it.
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                    targetNode.Expand();
                }
            }
        }
        // Optional: Select the dropped node and navigate (however you do it)
        treeView1.SelectedNode = draggedNode;
        // NavigateToContent(draggedNode.Tag);
    }
