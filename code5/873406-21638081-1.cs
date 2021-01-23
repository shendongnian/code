    //Determine type and separate key and value
    Type type = item.Key.GetType();
    if (type.Name.Equals("DataRow"))
    {
        zip = new ZipCodeError((DataRow)item.Key);
    }
    else if (type.Name.Equals("ZipCodeTerritory"))
    {
        zip = new ZipCodeError((ZipCodeTerritory)item.Key);
    }
    else
    {
        ...
    }
