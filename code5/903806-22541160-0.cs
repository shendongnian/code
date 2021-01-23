    string[] names = new string[100];
    StorageFolder folder = ApplicationData.Current.RoamingFolder;
    XmlWriterSettings set = new XmlWriterSettings();
    set.Encoding = Encoding.Unicode;
    
    XmlObjectSerializer serializer = new DataContractSerializer(typeof(string[]));
    Stream stream = await folder.OpenStreamForWriteAsync("filename", CreationCollisionOption.ReplaceExisting);
    XmlWriter writer = XmlWriter.Create(stream, set);
    serializer.WriteObject(writer, names);
