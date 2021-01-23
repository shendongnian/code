    public static class WebBrowserProperties
    {
        public static readonly DependencyProperty UrlProperty = DependencyProperty.RegisterAttached("Url", typeof(string), typeof(WebBrowserProperties), new UIPropertyMetadata(string.Empty, UrlPropertyChanged));
        public static string GetUrl(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(UrlProperty);
        }
        public static void SetUrl(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(UrlProperty, value);
        }
        public static void UrlPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null && GetUrl(webBrowser) != string.Empty)
            {
                webBrowser.Navigate(GetUrl(webBrowser));
                webBrowser.LoadCompleted += WebBrowserLoaded;
            }
        }
        public static void WebBrowserLoaded(object sender, NavigationEventArgs e)
        {
        }
    }
