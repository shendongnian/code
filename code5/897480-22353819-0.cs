     protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Clear();
            StreamReader stream = new StreamReader("Styles.xaml");
            Application.Current.Resources.MergedDictionaries.Add(System.Windows.Markup.XamlReader.Load(stream.BaseStream) as ResourceDictionary);
        }
