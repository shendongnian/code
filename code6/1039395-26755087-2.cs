    public class Helper
    {
        public static DataTable DataTableFromTextFile(string location, char delimiter = ',')
        {
            DataTable result;
            string[] LineArray = File.ReadAllLines(location);
            result = FormDataTable(LineArray, delimiter);
            return result;
        }
        private static DataTable FormDataTable(string[] LineArray, char delimiter)
        {
            DataTable dt = new DataTable();
            AddColumnToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);
            return dt;
        }
        private static void AddRowToTable(string[] valueCollection, char delimiter, ref DataTable dt)
        {
            for (int i = 1; i < valueCollection.Length; i++)
            {
                string[] values = valueCollection[i].Split(delimiter);
                DataRow dr = dt.NewRow();
                for (int j = 0; j < values.Length; j++)
                {
                    dr[j] = values[j];
                }
                dt.Rows.Add(dr);
            }
        }
        private static void AddColumnToTable(string[] columnCollection, char delimiter, ref DataTable dt)
        {
            string[] columns = columnCollection[0].Split(delimiter);
            foreach (string columnName in columns)
            {
                DataColumn dc = new DataColumn(columnName, typeof(string));
                dt.Columns.Add(dc);
            }
        }
    }
