        public static DataTable CompareTables(DataTable first, DataTable second)
        {
            second.PrimaryKey = new DataColumn[] {second.Columns["Name"]};
            DataTable difference = second.Clone();
            foreach (DataRow row in first.Rows) {
                if (second.Rows.Find(row["Name"]) == null)
                {
                    difference.ImportRow(row);
                }
            }
            return difference;
        }
