    private void pnlDrawArea_Paint(object sender, PaintEventArgs e)
    {
            int offset = 20;
            Rectangle bounding = new Rectangle(offset, offset, 
                                (int)myBoundary.Value, (int)myBoundary.Value);
            if (rbSquare.Checked)
            {
               e.Graphics.DrawRectangle(Pens.Red, bounding);
            }
            else if (rbCircle.Checked)
            {
               e.Graphics.DrawEllipse(Pens.Red, bounding);
            }
            // else if...
    }
