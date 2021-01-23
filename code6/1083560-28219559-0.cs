    private void GetCSVData(string CsvFileFullPath)
    {
        // Make sure that you add the Microsoft.VisualBasic.FileIO Namespace
        using (var lines = new TextFieldParser(CsvFileFullPath))
        {
            lines.HasFieldsEnclosedInQuotes = true;
            lines.SetDelimiters(",");
            lines.TrimWhiteSpace = true;
            try
            {
                while (!lines.EndOfData)
                {
                    string[] csvLineCols = lines.ReadFields();
                    for (int i = 0; i < csvLineCols.Count(); i++)
                    {
                        Console.WriteLine(csvLineCols[i].ToString());
                    }
                }
            }
            catch
            { }
        }
    }
