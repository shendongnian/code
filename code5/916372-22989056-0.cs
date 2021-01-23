    var isoFileStream = new IsolatedStorageFileStream("Saves\\itemList.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, store);
    var xDoc = XDocument.Load(isoFileStream);
    isoFileStream.Close();
    isoFileStream = new IsolatedStorageFileStream("Saves\\itemList.xml", FileMode.Create, FileAccess.ReadWrite, store);
                        var newItem = new XElement("Item",
                                new XElement("Name", ItemName.Text),
                                //all other elements here
                                new XElement("Method", method));
            xDoc.Root.Add(newItem);
            xDoc.Save(isoFileStream);
            isoFileStream.Close();
