    class CustomToolTip : ToolTip
    {
        public CustomToolTip()
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }
        // Sets the size of the CustomToolTip.
        private void OnPopup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(100, 100);
        }
 
        // Draws the CustomToolTip.
        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            // your drawing...
        }
    }
