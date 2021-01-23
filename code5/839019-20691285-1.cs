    void MouseUp(object sender, MouseEventArgs e) {
        if (ClientRectangle.Contains(PointToClient(Cursor.Position))) {
            // Your code here
        }
    }
