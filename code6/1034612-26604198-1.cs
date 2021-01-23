     // Your code for filling dataset
    foreach(dataTable theTable in dataSet.Tables)
        {
               foreach(DataRow row in theTable.Rows)
                {
                    foreach(DataColumn cell in theTable.Columns)
                    {
                        string value = row[cell].ToString();
                        row[cell] = "<a href='" + value + "'>" + value + "</a>";
                        
                    }
                }
        }
    //Your databinding and stuff;
