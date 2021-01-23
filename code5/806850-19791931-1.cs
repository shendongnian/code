    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            // Some sample existing items
            this.MyItems.ItemsSource = new[] { "one", "two", "three", "four", "five" };
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // This is a brute force attempt to scroll to the bottom of all content.
            // You may want to be smarter about when this is done, such as when a "\r"
            // is added to the end of the text in the textbox or the text is added
            // such that it forces a new line. Beware text being changed in the middle
            // of a large block of text as may not want that to trigger a scroll to the bottom.
            this.MyScrollViewer.ScrollToVerticalOffset(double.MaxValue);
        }
    }
