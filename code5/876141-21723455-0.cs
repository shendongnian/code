    DataTable dataTable = new DataTable();
                dataTable.Columns.Add("PK");
                dataTable.Columns.Add("A");
                dataTable.Columns.Add("B");
                dataTable.Columns.Add("AA");
                dataTable.Columns.Add("BB");
    
                DataRow drRow = dataTable.NewRow();
                drRow[0] = 1;
                drRow[1] = 2;
                drRow[2] = 1;
                drRow[3] = 2;
                drRow[4] = 1;
                dataTable.Rows.Add(drRow);
    
                drRow = dataTable.NewRow();
                drRow[0] = 3;
                drRow[1] = 4;
                drRow[2] = 12;
                drRow[3] = 23;
                drRow[4] = 14;
                dataTable.Rows.Add(drRow);
    
                
                DataTable newTable = new DataTable();
               
                newTable.Columns.Add("PK");
                newTable.Columns.Add("A");
                newTable.Columns.Add("B");
                newTable.Columns.Add("C");
    
                newTable.ExtendedProperties.Add("TimeStamp",DateTime.Now);
    
                drRow = newTable.NewRow();
                drRow[0] = 5;
                drRow[1] =6;
                drRow[2] = 5;
                drRow[3] = 6;
                newTable.Rows.Add(drRow);
    
                drRow = newTable.NewRow();
                drRow[0] = 7;
                drRow[1] = 8;
                drRow[2] = 55;
                drRow[3] = 66;
                newTable.Rows.Add(drRow);
                
                dataTable.Merge(newTable,false);
