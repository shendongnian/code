    private List<MyObject> ConvertBackToObject(DataTable dataTable)
        {
            // basically the same procedure as assigning
            List<MyObject> listMyDataSource = new List<MyObject>();
            foreach (DataRow row in dataTable.Rows)
            {
                MyObject myObject = new MyObject
                {
                    ID = Convert.ToInt16(row["ID"]),
                    Name = row["Name"].ToString(),
                    List = new List<string>()
                };
                foreach (var column in dataTable.Columns.Cast<DataColumn>().Where(col => col.ColumnName.StartsWith("ItemNr")))
                {
                    myObject.List.Add(row[column].ToString());
                }
                listMyDataSource.Add(myObject);
            }
            return listMyDataSource;
        }
