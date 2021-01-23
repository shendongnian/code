    foreach(dataTable theTable in dataSet.Tables)
            {
                   foreach(DataRow row in theTable.Rows)
                    {
                        foreach(DataColumn cell in theTable.Columns)
                        {
                            string value = row[cell].ToString();
                            HyperLink link = new HyperLink();
                           link.NavigateUrl = value; // you need to change this so it works
                            row[cell] = link;
                            
                        }
                    }
            }
