            ////////////////////////////////////////////////////////////////////////
            //Change Priority Strip
            ////////////////////////////////////////////////////////////////////////
            ContextMenuStrip changePriority = new ContextMenuStrip();
            ToolStripMenuItem highPriority = new ToolStripMenuItem("High Priority");
            changePriority.Items.Add(highPriority);
            highPriority.Click += new EventHandler(changePriorityHighEvent);
            ToolStripMenuItem normalPriority = new ToolStripMenuItem("Normal Priority");
            changePriority.Items.Add(normalPriority);
            normalPriority.Click += new EventHandler(changePriorityNormalEvent);
            ToolStripMenuItem lowPriority = new ToolStripMenuItem("Low Priority");
            changePriority.Items.Add(lowPriority);
            lowPriority.Click += new EventHandler(changePriorityLowEvent);
            ////////////////////////////////////////////////////////////////////////
            private void gridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)                                //On Right Click
                {
                    DataGridView.HitTestInfo hit = gridView.HitTest(e.X, e.Y);     //Get the clicked cell
                    if (e.RowIndex < 0)                                            //If it's a header, ignore
                        return;
                    gridView.CurrentCell = gridView[e.ColumnIndex, e.RowIndex];    //Select the cell for future info
                    if (gridView.CurrentCell.ColumnIndex == 6)                     //If this is the priority column
                    {
                        changePriority.Show(Cursor.Position.X, Cursor.Position.Y); //Show the strip
                    }
                 }
             }
             private void changePriorityHighEvent(Object sender, EventArgs e) {
                 //make changes
             }
             private void changePriorityNormalEvent(Object sender, EventArgs e) {
                 //make changes
             }
             private void changePriorityLowEvent(Object sender, EventArgs e) {
                 //make changes
             }
