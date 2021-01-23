             string ItemNumber = "ItemNumber";
             string Price = "Price";
             DataTable priceListTable = new DataTable();
             DataRow row;
             priceListTable.Columns.Add(ItemNumber);
             priceListTable.Columns.Add(Price);
           foreach(string s in recordList)
           {
               row = priceListTable.NewRow();
               row[ItemNumber] = s[0];
               row[Price] = s[1];
               priceListTable.Rows.Add(row);
            }
