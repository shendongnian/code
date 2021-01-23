    DataTable myDataTable = new DataTable();
          
          DataColumn quantityColumn = new DataColumn("Quantity");
          DataColumn rateColumn = new DataColumn("Rate");
          DataColumn priceColumn = new DataColumn ("Price");
          
          quantityColumn.DataType = typeof(int);
          rateColumn.DataType = typeof(int);
          
          myDataTable.Columns.Add(quantityColumn);
          myDataTable.Columns.Add(rateColumn);
          myDataTable.Columns.Add(priceColumn);
          
          //Set the Expression here
          priceColumn.Expression = "Quantity * Rate";
