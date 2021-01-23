    private void treeView1_DragDrop(object sender, DragEventArgs e)
    {
        TreeNode draggedNode = (MatfloNode)drgevent.Data.GetData(typeof(TreeNode));
        Point pt = this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y));
        TreeNode targetNode = this.GetNodeAt(pt);
        TreeNode parentNode = targetNode;
        if (draggedNode != null &&
            targetNode != null  )
        {
            bool canDrop = true;
            while (canDrop && (parentNode != null))
            {
                canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                parentNode = parentNode.Parent;
            }
            if (canDrop)
            {
                draggedNode.Remove();
                targetNode.Nodes.Add(draggedNode);
                targetNode.Expand();
            }
        }
    }
