        private Point previousLocation;
    private Size previousSize; 
    private void FullScreen()
    {
            
        if (!IsFullScreen()) //Form is resized to FullScreen, only if it's not already 'fullscreened'
        {
            previousLocation = this.Location;
            previousSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }
        else
        {
            /*Form goes back to whatever size, location, and form border style 
            it had before I pressed CTRL + ALT + ENTER*/
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Location = previousLocation;
            this.Size = previousSize;
        }
    }
