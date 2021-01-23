    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
     {
        if (null != node)
         {
             //Reset the color when selected node changes
             node.BackColor = Color.White;
         }
    
         //Set the currently selected node color
         e.Node.BackColor = Color.Green;
    
         node = e.Node;
     }
