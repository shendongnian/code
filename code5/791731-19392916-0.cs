            using (SqlConnection conn = new SqlConnection("<ConnectionString>"))
            {
                string[] restrictions = new string[4] { null, null, "<TableName>", null };
                conn.Open();
                var columnList = conn.GetSchema("Columns", restrictions).AsEnumerable().Select(s => s.Field<String>("Column_Name")).ToList();
            }
