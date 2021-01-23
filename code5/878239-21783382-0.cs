        public static DataTable GetVal(DateTime startDate, DateTime endDate, DataTable dt)
        {
            using (var myTable = dt.Clone())
            {
                var dr = from row in myTable.AsEnumerable()
                    where row.Field<DateTime>("C_START") >= startDate
                       && row.Field<DateTime>("C_END") <= endDate
                    select new {row};
                foreach (var row in dr)
                {
                    myTable.Rows.Add(row);
                }
                return myTable;
            }
         }
