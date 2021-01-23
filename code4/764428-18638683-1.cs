    private async Task LoadXml()
    {
        StorageFolder storageFolder = Package.Current.InstalledLocation;
        StorageFile storageFile = await storageFolder.GetFileAsync("players2.xml");
    
        string xml = await FileIO.ReadTextAsync(storageFile, Windows.Storage.Streams.UnicodeEncoding.Utf8);
    
        var doc = XDocument.Parse(xml);
        var rootNode = doc.Root;
        foreach (var child in rootNode.Descendants("player"))
        {
            var objPlayer = new PlayerModel
            {
                ID = child.Element("id").Value,
                Name = child.Element("name").Value,
                ShirtNumber = child.Element("shirtnumber").Value,
                Position = child.Element("position").Value
            };
    
            Items.Add(objPlayer);
        }
    
        ic.ItemsSource = Items;
    }
