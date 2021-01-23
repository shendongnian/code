    private void treeList1_DragDrop(object sender, DragEventArgs e)
    {
        var draggedNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode; //null        
        var targetNode = Tree.ViewInfo.GetHitTest(Tree.PointToClient(new Point(e.X, e.Y))).Node; // null
        if (targetNode == null) return;
        if (draggedNode != null)
        {
            if (targetNode[treeListColumn3].ToString() == "File")
            {
                if (targetNode.ParentNode == draggedNode.ParentNode)
                    return;
                MoveInFolder(draggedNode, targetNode.ParentNode);
            }
            else
            {
                MoveInFolder(draggedNode, targetNode);
            }
            e.Effect = DragDropEffects.None;            
        }
        else
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null) return;
            //Do something with your TreeList
        }
    }  
