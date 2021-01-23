    ListViewItem heldDownItem;
    Point heldDownPoint;
    //MouseDown event handler for your listView1
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {            
        //listView1.AutoArrange = false;
        heldDownItem = listView1.GetItemAt(e.X,e.Y);
        if (heldDownItem != null) {
          heldDownPoint = new Point(e.X - heldDownItem.Position.X, 
                                    e.Y - heldDownItem.Position.Y);
        }
    }
    //MouseMove event handler for your listView1
    private void listView1_MouseMove(object sender, MouseEventArgs e)
    {
        if (heldDownItem != null){
            heldDownItem.Position = new Point(e.Location.X - heldDownPoint.X, 
                                              e.Location.Y - heldDownPoint.Y);
        }
    }
    //MouseUp event handler for your listView1
    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
        heldDownItem = null;
        //listView1.AutoArrange = true;         
    }
