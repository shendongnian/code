    //Shortened refs so as to not collide with WPF classes of the same name
    using Drawing = System.Drawing;
    using Forms = System.Windows.Forms;
    //Method to determine the center point of the screen your Window is contained in, based on the window's top-left most point.
    Drawing.Point p = new Drawing.Point((int)this.Left, (int)this.Top);
    Forms.Screen screen = Forms.Screen.FromPoint(p);
    Drawing.Rectangle screenRect = screen.Bounds;
    int centerX = screenRect.Left + screenRect.Width / 2;
    int centerY = screenRect.Top + screenRect.Height / 2;
