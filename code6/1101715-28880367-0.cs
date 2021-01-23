            var path = string.Format(@"C:\Users\jlambert\Desktop\encryptedSSNs.xlsx");
            var connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
            var adapter = new OleDbDataAdapter("SELECT * FROM [sheetName$]", connStr);
            var ds = new DataSet();
            adapter.Fill(ds, "anyNameHere");
            var data = ds.Tables["anyNameHere"].AsEnumerable();
            var query = data.Where(x => x.Field<string>("MRN") != string.Empty).Select(x =>
                new 
                {
                    mrn = x.Field<string>("MRN"),
                    ssn = x.Field<string>("ssn"),
                });
            foreach (var q in query)
            {
                Console.WriteLine(q);    
            }
            Console.ReadLine();
