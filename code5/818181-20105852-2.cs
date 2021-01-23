    public void WriteToDoc(XmlDocument doc, XElement element)
    {
        // this method can reside somewhere outside.
        // some generic doc loader can load the doc   
        // add element to doc
    }
    public void OnButton1Click(object sender, RoutedEventArgs e)
    {
        // do something with element
        WriteToDoc( mydoc, myNewElement)
    }
    public void OnButton2Click(object sender, RoutedEventArgs e)
    {
        // do something else with element
        WriteToDoc( mydoc, myNewElement)
    }
