    public void mouseMove(MouseEventArgs e) {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Point currentPos = Location;
            currentPos.Offset(e.X + mousePoint.X, e.Y + mousePoint.Y);
            this.Location = currentPos;
        }
        //Or simply use Location.Offset(e.X + mousePoint.X, e.Y + mousePoint.Y);
    }
