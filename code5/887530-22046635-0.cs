    using System;
    using System.IO;
    namespace sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Read all lines from csv file describing single table
                string query = "CREATE TABLE ";
                using (StreamReader sr = new StreamReader(File.OpenRead(@"C:\test\test.csv"))){
                    // Skip the first line
                    sr.ReadLine();
                    // Get the header from the second line
                    query += sr.ReadLine().Split(',')[0] + '(';
                    while (!sr.EndOfStream)
                    {
                        // Add parameters to query
                        string[] line = sr.ReadLine().Split(',');
                        query += line[0] + ' ' + line[1] + ',';
                    }
                    query = query.TrimEnd(',');
                    query += ");";
                    Console.WriteLine(query);
                }
            }
        }
    }
