    private FrameworkElement LoadUI()
    {
        // Read the text as string from the file
        var xamlText = File.ReadAllText(_selectedXAML);
        // Replace variable values and script value pairs
        var stringReader = new StringReader(xamlText);
        var xmlReader = XmlReader.Create(stringReader);
        return XamlReader.Load(xmlReader) as FrameworkElement;
    }
    private void MainWindow_OnLoaded( object sender, RoutedEventArgs e )
    {
        var s = LogicalTreeHelper.GetChildren(LoadUI());
    }
