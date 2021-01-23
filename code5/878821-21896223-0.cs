    // ...
    uint id = 1;
    bool valid = false;
    while (!valid)
    {
        uint temp = id;
        foreach (OpenXmlElement e in sheets.ChildElements)
        {
            var s = e as Sheet;
            if (id == s.SheetId.Value)
            {
                id++;
                break;
            }
        }
        if (temp == id)
            valid = true;
    }
    sheet.SheetId = id;
    //...
 
