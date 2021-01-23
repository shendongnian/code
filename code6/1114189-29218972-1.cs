    int? id = null;
    Int32.TryParse(collection["ID_NUM"], out id);
    string last = collection["LAST_NAME"];
    ...
    var nameAndAddresses = db.NAME_AND_ADDRESS;
    if (id.HasValue)
    {
        nameAndAddresses = nameAndAddresses.Where(m => m.ID_NUM == id.Value);
    }
    if (!string.IsNullOrWhiteSpace(last))
    {
        nameAndAddress = nameAndAddresses.Where(m => m.LAST_NAME == last);
    }
    ViewResults.NAME_AND_ADDRESS = nameAndAddresses.FirstOrDefault();
