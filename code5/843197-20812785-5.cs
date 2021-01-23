    // To keep the content of the grid keyed on the BatchNumber field   
    Dictionary<string, MyItem> items = new Dictionary<string, MyItem>();
    for (int rowIndex = 0; i < dtCurrentTable.Rows.Count; i++)
    {
       MyItem itm = new MyItem();
       itm.DealerCode = HFDealerCode.Value.ToString();
       itm.ItemCode = GetGridValue(rowIndex, 2, "ItemIdentityCode"); 
       itm.Quantity = Convert.ToDecimal(GetGridValue(rowIndex, 8, "Quantity");
       itm.ExpireDate = Convert.ToDateTime(GetGridValue(rowIndex, 6, "ExpireDate");
       itm.BatchNumber = GetGridValue(rowIndex, 7, "BatchNumber");
       // Add the item to the dictionary for future reuses, however if you just want to store
       // the item in the database this line is not needed
       items.Add(itm.BatchNumber, itm);
       
       // notice that the storing is executed inside the loop that extracts the values
       // so every row is updated/inserted in the database
       InsertDEL_Stores(itm);
    }
