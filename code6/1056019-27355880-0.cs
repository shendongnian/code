     class CheckVersion
    {
        public static bool isOldSystem;
        public static void CheckColumnsInMasterInventory()
        {
            string[] Columns = { "Col1", "Col2", "Col3", "Col4" };//New Columns Which are not present in Old table.
            List<string> ColumnList = new List<string>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (var schemaCommand = new SqlCommand("SELECT * FROM dbo.Table1", con))
                {
                    con.Open();
                    using (var reader = schemaCommand.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataColumn column in dt.Columns)
                        {
                            ColumnList.Add(column.ColumnName);
                        }
                    }
                }
            }
            var columnCount = ColumnList.Where(item => Columns.Contains(item)).Count();
            if (columnCount == 4)
                isOldSystem = false;
            else
                isOldSystem = true;
        }
    }
