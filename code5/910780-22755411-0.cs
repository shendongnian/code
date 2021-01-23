    public class MyUserControl : UserContro
    {
        public event EventHandler ImageButtonClicked;
    
        private void ImageButton1_Click(object sender, EventArgs e)
        {
            if (ImageButtonClicked != null)  // Check against null as there may not be any subscribers
                ImageButtonClicked(this, EventArgs.Empty);
        }
    
        // ...
    }
