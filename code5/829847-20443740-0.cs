    class BaseLabelGray : Label
    {
        public BaseLabelGray()
        {
            this.BackColor = Color.Transparent;
        }
    
        public bool IsSelected { get; set; }
    
        protected override void OnMouseEnter(EventArgs e)
        {
            this.ForeColor = Color.White;
            this.Cursor = Cursors.Hand;
        }
    
        protected override void OnMouseLeave(EventArgs e)
        {
            this.ForeColor = IsSelected ? SelectedColor : Color.Gray;
            this.Cursor = Cursors.Arrow;
        }
    }
