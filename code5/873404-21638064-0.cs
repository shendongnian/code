    if ( item.Key is DataRow )
    {
        zip = new ZipCodeError((DataRow)item.Key);
    }
    else if ( item.Key is ZipCodeTerritory )
    {
        zip = new ZipCodeError((ZipCodeTerritory)item.Key);
    }
    else
    {
        ...
    }
