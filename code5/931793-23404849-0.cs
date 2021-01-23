     FrameworkElement loadedRoot = (FrameworkElement)XamlReader.Load(xmlReader);
     loadedRoot.Loaded += new RoutedEventHandler(loadedRoot_Loaded);
     LibovLoad.Children.Add(loadedRoot);
     void loadedRoot_Loaded(object sender, RoutedEventArgs e)
     {
         Canvas canvas = (sender as FrameworkElement).FindName("LibovPhoto"); // not null
     }
