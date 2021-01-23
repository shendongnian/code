    for (int i = 0; i < oldTable.Rows.Count; i++)
            {
                DataColumn newHeader = new DataColumn();
                newHeader.ColumnName = oldTable.Rows[i].ItemArray[3].ToString();             
                newHeader.DataType =typeof(System.Boolean); //Change This Line Like This
               newTable.Columns.Add(newHeader);                
            }
