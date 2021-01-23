        bool clicked = false;
        int iOldX;
        int iOldY;
        int iClickX;
        int iClickY;
        void labelWorker_MouseDown(object sender, MouseEventArgs e)
        {
            Label labelWorker = (Label)sender;
            if (e.Button == MouseButtons.Left)
            {
                Point p = ConvertFromChildToForm(e.X, e.Y, labelWorker);
                iOldX = p.X;
                iOldY = p.Y;
                iClickX = e.X;
                iClickY = e.Y;
                clicked = true;
            }
        }
        void labelWorker_MouseMove(object sender, MouseEventArgs e)
        {
            Label labelWorker = (Label)sender;
            if (clicked)
            {
                Point p = new Point(); // New Coordinate
                p.X = e.X + labelWorker.Left;
                p.Y = e.Y + labelWorker.Top;
                labelWorker.Left = p.X - iClickX;
                labelWorker.Top = p.Y - iClickY;
            }
        }
        void labelWorker_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private Point ConvertFromChildToForm(int x, int y, Control control)
        {
            Point p = new Point(x, y);
            control.Location = p;
            return p;
        }
