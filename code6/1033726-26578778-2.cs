    var toAdd = dbDesc.Except(xmlData, new DatabaseDescriptorComparer() ).ToList();
    foreach(var x in toAdd){
        xmlData.Databases.Add(
            new xml.DatabaseDescriptor() { DatabaseName = x.Name, Tables = newTable }
        );
    }
