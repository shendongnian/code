        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            var hit = treeView1.HitTest(e.Location);
            if (hit.Location == TreeViewHitTestLocations.Label) {
                // etc..
            }
        }
 
