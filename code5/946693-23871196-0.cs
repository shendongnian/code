    string path = Server.MapPath("Twitter Overview Report1.csv"); 
        using (CsvFileReader reader = new CsvFileReader(path))
        {
            CsvRow row = new CsvRow();
            while (reader.ReadRow(row))
            {
                foreach (string s in row)
                {
                    string s_row = row[0].ToString();
                    s_row.Replace("mahmoude", "Ghandour");
                }
                Console.WriteLine();
            }
        }
        using (CsvFileWriter writer = new CsvFileWriter(path))
        {
 
        }
