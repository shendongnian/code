            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0; HDR=YES", fileName);
            var adapter = new OleDbDataAdapter("SELECT * FROM [sheet1$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "mySheet");
            var data = ds.Tables["mySheet"].AsEnumerable();
            foreach (DataRow dataRow in data)
            {
                Console.WriteLine(dataRow["MyColumnName"].ToString());    
                Console.WriteLine(dataRow.Field<string>("MyColumnName").ToString());
            }
