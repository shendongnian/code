        private static ProjectKeys _AllStyleKeys = new ProjectKeys();
        public static ProjectKeys AllStyleKeys {
            get {
                return _AllStyleKeys; 
            } set {
                _AllStyleKeys = value; 
            } 
        }
        public App() {
            Uri sUri = new Uri("/KeyCheck;component/Dictionary1.xaml", UriKind.Relative);
            ResourceDictionary r = new ResourceDictionary();
            r.Source = sUri;
            Resources.MergedDictionaries.Add(r);
            AllStyleKeys.StyKey = (Style)App.Current.Resources["MyKey"]; 
        }
        
