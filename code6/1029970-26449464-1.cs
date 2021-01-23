    private Rectangle dragBoxFromMouseDown;
    private int colIndexFromMouseDown;
    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            // If the mouse moves outside the rectangle, start the drag.
            if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
            {
                // Proceed with the drag and drop, passing in the list item.                    
                dataGridView1.DoDragDrop(colIndexFromMouseDown, DragDropEffects.Move);
            }
        }
    }
    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        // Get the index of the item the mouse is below.
        colIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).ColumnIndex;
        if (colIndexFromMouseDown != -1)
        {
            // Remember the point where the mouse down occurred. 
            // The DragSize indicates the size that the mouse can move 
            // before a drag event should be started.                
            Size dragSize = SystemInformation.DragSize;
            // Create a rectangle using the DragSize, with the mouse position being
            // at the center of the rectangle.
            dragBoxFromMouseDown = new Rectangle(
                new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)),
                dragSize);
        }
        else
            // Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = Rectangle.Empty;
    }
    private void dataGridView1_DragOver(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    }
    private void dataGridView1_DragDrop(object sender, DragEventArgs e)
    {
        // If the drag operation was a move then remove and insert the column.
        if (e.Effect == DragDropEffects.Move)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
            // Get the column index of the item the mouse is below. 
            int colIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).ColumnIndex;
            if (e.Data.GetDataPresent(typeof(int)))
            {
                int colToMove = (int)e.Data.GetData(typeof(int));
                dataGridView1.Columns[colToMove].DisplayIndex = colIndexOfItemUnderMouseToDrop;
            }
        }
    }
