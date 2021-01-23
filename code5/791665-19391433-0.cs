    bool stopDrag = true;
         private void listView1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                // Store the mouse position
                startPoint = e.GetPosition(null);
    stopDrag = false;
            }
        
            private void listView1_MouseMove(object sender, MouseEventArgs e)
            {
    if(stopDrag)
       return;
    
                // Get the current mouse position
                Point mousePos = e.GetPosition(null);
                Vector diff = startPoint - mousePos;
        
                if (e.LeftButton == MouseButtonState.Pressed &&
                    (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    // Get the dragged ListViewItem
                    ListView listView = sender as ListView;
        
                    // Get items to drag
                    var a = listView.SelectedItems;
        
                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", a);
                    DragDrop.DoDragDrop(listView, dragData, DragDropEffects.Move);
                } 
            }
    
    private void listView1_MouseUp(...)
    {
    stopDrag = true;
    }
