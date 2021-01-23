    private static List<List<string>> GetAllLineFields(string fullPath)
    {
        List<List<string>> allLineFields = new List<List<string>>();
        var fileInfo = new System.IO.FileInfo(fullPath);
        using (var reader = new System.IO.StreamReader(fileInfo.FullName, Encoding.Default))
        {
            Char quotingCharacter = '\0'; // no quoting-character;
            Char escapeCharacter = quotingCharacter;
            Char delimiter = '|';
            using (var csv = new CsvReader(reader, true, delimiter, quotingCharacter, escapeCharacter, '\0', ValueTrimmingOptions.All))
            {
                csv.DefaultParseErrorAction = ParseErrorAction.ThrowException;
                //csv.ParseError += csv_ParseError;
                csv.SkipEmptyLines = true;
                while (csv.ReadNextRecord())
                {
                    //string currentLine = csv.GetCurrentRawData();
                    List<string> fields = new List<string>(csv.FieldCount);
                    for (int i = 0; i < csv.FieldCount; i++)
                    {
                        try
                        {
                            string field = csv[i];
                            fields.Add(field.Trim('"'));
                        } catch (MalformedCsvException ex)
                        {
                            // log, should not be possible anymore
                            throw;
                        }
                    }
                    allLineFields.Add(fields);
                }
            }
        }
        return allLineFields;
    }
