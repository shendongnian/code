        [TestMethod]
        public void SQLCommandVsAddaptor()
        {
            long adaptorFillLargeTableTime, readerLoadLargeTableTime, adaptorFillMediumTableTime, readerLoadMediumTableTime, adaptorFillSmallTableTime, readerLoadSmallTableTime, adaptorFillTinyTableTime, readerLoadTinyTableTime;
            string LargeTableToFill = "select top 10000 * from FooBar";
            string MediumTableToFill = "select top 1000 * from FooBar";
            string SmallTableToFill = "select top 100 * from FooBar";
            string TinyTableToFill = "select top 10 * from FooBar";
            using (SqlConnection sconn = new SqlConnection("Data Source=.;initial catalog=riksja_global;persist security info=True; user id=pricingengine;password=pricingengine;"))
            {
                // large data set measurements
                adaptorFillLargeTableTime = MeasureExecutionTimeMethod(sconn, LargeTableToFill, ExecuteDataAdapterFillStep);
                readerLoadLargeTableTime = MeasureExecutionTimeMethod(sconn, LargeTableToFill, ExecuteSqlReaderLoadStep);
                // medium data set measurements
                adaptorFillMediumTableTime = MeasureExecutionTimeMethod(sconn, MediumTableToFill, ExecuteDataAdapterFillStep);
                readerLoadMediumTableTime = MeasureExecutionTimeMethod(sconn, MediumTableToFill, ExecuteSqlReaderLoadStep);
                // small data set measurements
                adaptorFillSmallTableTime = MeasureExecutionTimeMethod(sconn, SmallTableToFill, ExecuteDataAdapterFillStep);
                readerLoadSmallTableTime = MeasureExecutionTimeMethod(sconn, SmallTableToFill, ExecuteSqlReaderLoadStep);
                // tiny data set measurements
                adaptorFillTinyTableTime = MeasureExecutionTimeMethod(sconn, TinyTableToFill, ExecuteDataAdapterFillStep);
                readerLoadTinyTableTime = MeasureExecutionTimeMethod(sconn, TinyTableToFill, ExecuteSqlReaderLoadStep);
            }
            using (StreamWriter writer = new StreamWriter("result_sql_compare.txt"))
            {
                writer.WriteLine("10000 rows");
                writer.WriteLine("Sql Data Adapter 100 times table fill speed 10000 rows: {0} milliseconds", adaptorFillLargeTableTime);
                writer.WriteLine("Sql Data Reader 100 times table load speed 10000 rows: {0} milliseconds", readerLoadLargeTableTime);
                writer.WriteLine("1000 rows");
                writer.WriteLine("Sql Data Adapter 100 times table fill speed 1000 rows: {0} milliseconds", adaptorFillMediumTableTime);
                writer.WriteLine("Sql Data Reader 100 times table load speed 1000 rows: {0} milliseconds", readerLoadMediumTableTime);
                writer.WriteLine("100 rows");
                writer.WriteLine("Sql Data Adapter 100 times table fill speed 100 rows: {0} milliseconds", adaptorFillSmallTableTime);
                writer.WriteLine("Sql Data Reader 100 times table load speed 100 rows: {0} milliseconds", readerLoadSmallTableTime);
                writer.WriteLine("10 rows");
                writer.WriteLine("Sql Data Adapter 100 times table fill speed 10 rows: {0} milliseconds", adaptorFillTinyTableTime);
                writer.WriteLine("Sql Data Reader 100 times table load speed 10 rows: {0} milliseconds", readerLoadTinyTableTime);
            }
            Process.Start("result_sql_compare.txt");
        }
        private long MeasureExecutionTimeMethod(SqlConnection conn, string query, Action<SqlConnection, string> Method)
        {
            long time; // know C#
            // execute single read step outside measurement time, to warm up cache or whatever
            Method(conn, query);
            // start timing
            time = Environment.TickCount;
            for (int i = 0; i < 100; i++)
            {
                Method(conn, query);
            }
            // return time in milliseconds
            return Environment.TickCount - time;
        }
        private void ExecuteDataAdapterFillStep(SqlConnection conn, string query)
        {
            DataTable tab = new DataTable();
            conn.Open();
            using (SqlDataAdapter comm = new SqlDataAdapter(query, conn))
            {
                // adaptor fill table function
                comm.Fill(tab);
            }
            conn.Close();
        }
        private void ExecuteSqlReaderLoadStep(SqlConnection conn, string query)
        {
            DataTable tab = new DataTable();
            conn.Open();
            using (SqlCommand comm = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    // IDataReader Load function
                    tab.Load(reader);
                }
            }
            conn.Close();
        }
