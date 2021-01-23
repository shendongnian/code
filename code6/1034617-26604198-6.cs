    foreach(dataTable theTable in dataSet.Tables)
            {
                   foreach(DataRow row in theTable.Rows)
                    {
                        foreach(DataColumn cell in theTable.Columns)
                        {
                           string value = row[cell].ToString();
                          HyperLink linker = new HyperLink();
                           DataColumn col = new DataColumn();
               
                         linker.NavigateUrl = value; // you need to change this so it works
                         col.DefaultValue = linker;
                          row[cell] = col;
                            
                        }
                    }
            }
