        //Add more parameters based on your conditions
        public static DataTable GetVal(DateTime startDate, DateTime endDate, DataTable dt)
        {
            using (var myTable = dt.Clone())
            {
                var dr = from row in myTable.AsEnumerable()
                    where row.Field<DateTime>("C_START") >= startDate
                       && row.Field<DateTime>("C_END") <= endDate
                       //Add more && statements to complete the query as needed.
                       //A string query is OK but you are prone to mistakes, why not let the compiler do the work.
                    select new {row};
                foreach (var row in dr)
                {
                    myTable.Rows.Add(row);
                }
                return myTable;
            }
         }
