        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath shape = new System.Drawing.Drawing2D.GraphicsPath();
            shape.AddRectangle(new Rectangle(8, 40, 200, 200));
            // I just picked a shape.  The user will see whatever exists in these pixels of the form.
            // After you get it going, make sure that things not on the visible area are disabled.  
            // A user can't click on them but they could tab to them and hit ENTER.
            // Give the user a way to close it other than Alt-F4, stuff like that.
            this.Region = new System.Drawing.Region(shape);
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - 160) / 2;
            this.Left = Screen.PrimaryScreen.WorkingArea.Left;
        }
        private void Form1_MouseHover(object sender, EventArgs e)
        {
            this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));
        }
