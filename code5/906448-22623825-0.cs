    private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            mousex = Cursor.Position.X;
            mousey = Cursor.Position.Y;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(e.X, e.Y, 20, 20));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
