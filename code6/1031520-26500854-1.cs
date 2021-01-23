    using CsvHelper;
    public static List<T> CSVImport<T,TClassMap>(string csvData, bool hasHeaderRow, char delimiter, out string errorMsg) where TClassMap : CsvHelper.Configuration.CsvClassMap
        {
            errorMsg = string.Empty;
            var result = Enumerable.Empty<T>();
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(csvData));
            StreamReader streamReader = new StreamReader(memStream);
            var csvReader = new CsvReader(streamReader);
            csvReader.Configuration.RegisterClassMap<TClassMap>();
            csvReader.Configuration.DetectColumnCountChanges = true;
            csvReader.Configuration.IsHeaderCaseSensitive = false;
            csvReader.Configuration.TrimHeaders = true;
            csvReader.Configuration.Delimiter = delimiter.ToString();
            csvReader.Configuration.SkipEmptyRecords = true;
            List<T> items = new List<T>();
            try
            {
                items = csvReader.GetRecords<T>().ToList();
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    errorMsg += ex.Message + Environment.NewLine;
                    foreach (var val in ex.Data.Values)
                        errorMsg += val.ToString() + Environment.NewLine;
                    ex = ex.InnerException;
                }
            }
            return items;
        }
    }
