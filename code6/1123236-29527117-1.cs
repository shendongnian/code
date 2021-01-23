            foreach (DataTable dt in userInfo)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    // if you want column names here is how you would get them
                    string columnName = column.ColumnName;
                    foreach (DataRow row in dt.Rows)
                    {
                        // if you want the values in the cells, here's where you get them
                        object value = row[column];
                    }
                }
            }
