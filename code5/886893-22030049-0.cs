        private void btnOpenAndGo_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser web = new WebBrowser();
            web.Height = LayoutRoot.Height;
            web.Width = LayoutRoot.Width;
            LayoutRoot.Children.Add(web);
            web.Navigate(...);
        }
