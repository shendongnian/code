        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            e.Graphics.DrawLine(pen, 0, 0, 50, 0 );
            e.Graphics.DrawLine(pen, 0, 0, 0, 50);
        }
