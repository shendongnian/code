    class CustomTabPage : TabPage
    {
        TextBox tbCode = new TextBox();
        public CustomTabPage()
        {
            SizeChanged += CustomTabPage_SizeChanged;
        }
    
        void CustomTabPage_SizeChanged(object sender, EventArgs e)
        {
            OnThisControlSizeChanged();
        }
    
        public CustomTabPage(string title)
        {
            tbCode.Multiline = true;
            tbCode.Size = this.Size;
        }
    
        private void OnThisControlSizeChanged()
        {
            tbCode.Size = this.Size;
        }
    }
