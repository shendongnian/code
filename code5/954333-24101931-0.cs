     private static void JoinCsvFiles(string[] csvFileNames, string outputDestinationPath)
        {
            StringBuilder sb = new StringBuilder();
            bool columnHeadersRead = false;
            foreach (string csvFileName in csvFileNames)
            {
                TextReader tr = new StreamReader(csvFileName);
                string columnHeaders = tr.ReadLine();
                // Skip appending column headers if already appended
                if (!columnHeadersRead)
                {
                    sb.AppendLine(columnHeaders);
                    columnHeadersRead = true;
                }
                sb.AppendLine(tr.ReadToEnd());
            }
            File.WriteAllText(outputDestinationPath, sb.ToString());
        }
