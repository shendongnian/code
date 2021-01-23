    DataRow aItem = Item.NewRow();
    Item["ID"] = 1.ToString();    
    Item["LineNumber"] = x;
    Item["ItemID"] = fieldRow[0].ToString();
    Item["UnitPrice"] = fieldRow[1].ToString();
    Item["Description"] = fieldRow[2].ToString();
    Item["OrderUOM"] = fieldRow[3].ToString();
    Item["OrderQty"] = fieldRow[4].ToString();
    Item.Rows.Add(aItem);
