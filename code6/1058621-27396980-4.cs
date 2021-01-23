    DataRow aItem = Item.NewRow();
    aItem["ID"] = 1.ToString();    
    aItem["LineNumber"] = x;
    aItem["ItemID"] = fieldRow[0].ToString();
    aItem["UnitPrice"] = fieldRow[1].ToString();
    aItem["Description"] = fieldRow[2].ToString();
    aItem["OrderUOM"] = fieldRow[3].ToString();
    aItem["OrderQty"] = fieldRow[4].ToString();
    Item.Rows.Add(aItem);
