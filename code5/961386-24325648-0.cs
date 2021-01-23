        protected override void OnLoad(EventArgs e) {
            var scr = Screen.FromPoint(this.Location);
            this.Bounds = new Rectangle(
                scr.WorkingArea.Left + 10, scr.WorkingArea.Top,
                scr.WorkingArea.Width - 20, scr.WorkingArea.Bottom);
            base.OnLoad(e);
        }
