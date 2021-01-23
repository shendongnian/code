    public SPListItemCollection GetSpecificLibraryItem(fileName)
    {
    SPList list = web.Lists["MyDocName"];
    SPQuery dQuery = new SPQuery();
    dQuery.ViewAttributes = "Scope=\"Recursive\"";
    string QueryString = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"FileLeafRef\"/>" +
                            "<Value Type=\"Text\">" + fileName + "</Value>" +
                          "</Eq>" +
                         "</Where>";
             dQuery.Query = QueryString;
            SPListItemCollection collListItems = list.GetItems(dQuery);
      return collListItems;
    }
 
