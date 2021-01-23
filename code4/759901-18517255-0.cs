    private void button1_Click(object sender, RoutedEventArgs e)
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                string site;
                site = textBox1.Text;
                webBrowser1.Navigate(new Uri(site, UriKind.Absolute));
                webBrowser1.LoadCompleted += webBrowser1_LoadCompleted;
            });
    }
    private void webBrowser1_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
            {
                string s = webBrowser1.SaveToString();
            }
