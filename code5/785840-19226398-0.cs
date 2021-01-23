    private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var hitTest = treeView1.HitTest(e.Location);
        if (hitTest.Location == TreeViewHitTestLocations.PlusMinus)
        { 
            //expand collapse clicked
        }
    }
