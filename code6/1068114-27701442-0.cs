    using System.IO;
    using System.Collections.Generic;
    using Ctl.Data;
    static IEnumerable<Dictionary<string, List<string>>> ReadCsv(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            CsvReader csv = new CsvReader(sr);
            // first read in the header.
            if (!csv.Read())
            {
                yield break; // an empty file, break out early.
            }
            RowValue header = csv.CurrentRow;
            // now the records.
            while (csv.Read())
            {
                Dictionary<string, List<string>> dict =
                    new Dictionary<string, List<string>>(header.Count);
                RowValue record = csv.CurrentRow;
                // map each column to a header value
                for (int i = 0; i < record.Count; ++i)
                {
                    // if there are more values in the record than the header,
                    // assume an empty string as header.
                    string headerValue = (i < header.Count ? header[i].Value : null)
                        ?? string.Empty;
                    // get the list, or create if it doesn't exist.
                    List<string> list;
                    if (!dict.TryGetValue(headerValue, out list))
                    {
                        dict[headerValue] = list = new List<string>();
                    }
                    // finally add column value to the list.
                    list.Add(record[i].Value);
                }
                yield return dict;
            }
        }
    }
