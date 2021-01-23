    XDocument doc = null;
    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Open, storage))
    {
        doc = XDocument.Load(isoStream);
        bool isUpdated = false;
        foreach (var item in (from item in doc.Descendants("Employee")
                         where item.Attribute("name").Value.Equals(empName)
                         select item).ToList())
        {
            // updating existing employee data
            // element already exists, need to update the existing attributes
            item.Attribute("name").SetValue(empName);
            item.Attribute("id").SetValue(id);
            item.Attribute("timestamp").SetValue(timestamp);
            isUpdated = true;
        }
        if (!isUpdated)
        {
            // adding new employee data
            doc.Element("Employee").Add(
                        new XAttribute("name", empName),
                        new XAttribute("id", id),
                        new XAttribute("timestamp", timestamp));
        }      
        //First way
        //isoStream.Position = 0;
        //doc.Save(isoStream);                  
    }
    //Or second way
    using (var stream = storage.OpenFile(fileName, FileMode.Open, FileAccess.Write))
    {
        doc.Save(stream);
    }       
