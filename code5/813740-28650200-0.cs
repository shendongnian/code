    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            Loaded += OnLoaded;
        }                 
     
        void OnLoaded(object sender, RoutedEventArgs e)
        {
            // the internal TextBoxView has a margin of 2,0,2,0 that needs to be removed
            var contentHost = Template.FindName("PART_ContentHost", this) as ScrollViewer;
            if (contentHost != null && contentHost.Content != null && contentHost.Content is FrameworkElement)
            {
                var textBoxView = contentHost.Content as FrameworkElement;
                textBoxView.Margin = new Thickness(0,0,0,0);
            }
        }       
    }
