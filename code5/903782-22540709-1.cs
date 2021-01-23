            string ItemNumber = "ItemNumber";
             string Price = "Price";
             DataTable priceListTable = new DataTable();
             DataRow row;
             priceListTable.Columns.Add(ItemNumber);
             priceListTable.Columns.Add(Price);
             int counter = 0;
             
             
            foreach(string s in recordList)
            {
                myTableSize++;
            }
            
           foreach(string s in recordList)
           {
               if (counter < myTableSize)
               {
                   row = priceListTable.NewRow();
                   row[ItemNumber] = recordList[counter];
                   row[Price] = recordList[counter + 1];
                   priceListTable.Rows.Add(row);
                   counter++;
                   counter++;
               }
