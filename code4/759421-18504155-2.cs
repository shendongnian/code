            var connectionString = "...";
            var copy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.Default);
            copy.DestinationTableName = "Customers";
            var reader = new SqlDataReader();
            var table = new DataTable();
            table.Load(reader);
            table.Columns.Add("DisplayName", typeof(string), "lastname, firstname");
            table.Columns.Add("CustomerCode", typeof(string));
            foreach (DataRow row in table.Rows)
                row["CustomerCode"] = ((int)row["id"] + 10000).ToString();
            copy.WriteToServer(table);
