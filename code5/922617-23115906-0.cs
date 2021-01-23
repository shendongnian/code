    // Load the dictionary
    ResourceDictionary resourceDictionary = null;
    var resourceStream = Application.GetResourceStream(new Uri("ResourceDictionary1.xaml", UriKind.Relative));
    if (resourceStream != null && resourceStream.Stream != null)
    {
        using (XmlReader xmlReader = XmlReader.Create(resourceStream.Stream))
        {
            resourceDictionary = XamlReader.Load(xmlReader) as ResourceDictionary;
        }
    }
