    private void MouseUp(object sender, MouseEventArgs e)
        {
            Point ptCursor = Cursor.Position;
            ptCursor = PointToClient(ptCursor);
            PictureBox pBox = (PictureBox)GetChildAtPoint(ptCursor);
            pBox.BackColor = System.Drawing.Color.Blue;
        } 
