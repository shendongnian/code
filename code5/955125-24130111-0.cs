    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            DataTable  dt = new DataTable();
            // Create Connection object
            using (SqlConnection conn = new SqlConnection(@"<Your Connection String>"))
            {
                // Create Command object
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM <Your Table>", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            dt.Load(reader);
                            using (StreamWriter writer = new StreamWriter("C:\\Temp\\dump.csv"))
                            {
                                DataConvert.ToCSV(dt, writer, false);
                            }
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                    }
                }
            }
            // Stop timing
            stopwatch.Stop();
            // Write result
            Console.WriteLine("Time elapsed: {0}",
                stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
    public static class DataConvert
    {
        public static void ToCSV(DataTable sourceTable, TextWriter writer, bool includeHeaders)
        {
            if (includeHeaders)
            {
                List<string> headerValues = new List<string>();
                foreach (DataColumn column in sourceTable.Columns)
                {
                    headerValues.Add(QuoteValue(column.ColumnName));
                }
                writer.WriteLine(String.Join(",", headerValues.ToArray()));
            }
            string[] items = null;
            foreach (DataRow row in sourceTable.Rows)
            {
                items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();
                writer.WriteLine(String.Join(",", items));
            }
            writer.Flush();
        }
        private static string QuoteValue(string value)
        {
            return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
        }
    } 
