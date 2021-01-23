            // sample data table
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Rows.Add(1, "John");
            dataTable.Rows.Add(2, "Mary");
            dataTable.Rows.Add(3, "Peter");
            dataTable.Rows.Add(4, "Sarah");
            // fill users list
            using (var reader = dataTable.CreateDataReader())
            {
                var users = Mapper.DynamicMap<IDataReader, List<User>>(reader);
            }
