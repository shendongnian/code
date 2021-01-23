    class BaseLabelGray : Label
    {
        private bool isSelected;
        public BaseLabelGray()
        {
            this.BackColor = Color.Transparent;
        }
        public Color SelectedColor { get; set; }
        public bool IsSelected 
        { 
            get { return isSelected; }
            set 
            {
                isSelected = value;
                ForeColor = isSelected ? SelectedColor : Color.Gray;
            }
        }
    
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
