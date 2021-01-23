    public static async Task<string> ReadFileTest(string xpath)
    {
        StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("NameOfFolderWithXML");
        StorageFile xmlFile = await folder.GetFileAsync("filename.xml");
        XmlDocument xmldoc = await XmlDocument.LoadFromFileAsync(xmlFile);
        var nodes = doc.SelectNodes(xpath);
        XmlElement element = (XmlElement)nodes[0];
        return element.GetXml();
    }
