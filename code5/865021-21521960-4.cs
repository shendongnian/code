        private void Button_Click(object sender, RoutedEventArgs e) {
            Uri sUri = new Uri("/KeyCheck;component/Dictionary1.xaml", UriKind.Relative);
            ResourceDictionary r = new ResourceDictionary();
            r.Source = sUri;
            App.Current.Resources.MergedDictionaries.Remove(r);
            sUri = new Uri("/KeyCheck;component/Dictionary2.xaml", UriKind.Relative);
            r = new ResourceDictionary(); 
            r.Source = sUri; 
            App.Current.Resources.MergedDictionaries.Add(r);
            var Style = App.Current.Resources["MyKey"] as Style;
            App.AllStyleKeys.StyKey = Style; 
        }
