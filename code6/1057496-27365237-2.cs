    public FileContentResult DownloadCSV()
    {
        string[][] output = new string[][]{  
            new string[]{"Col 1 Row 1", "Col 2 Row 1", "Col 3 Row 1"},  
            new string[]{"Col1 Row 2", "Col2 Row 2", "Col3 Row 2"}  
        };
        var result = lines.Select(l=>string.Join(",", l))
                          .Aggregate(new StringBuilder(), (sb, v) => sb.AppendLine(v))
                          .ToString();
        return File(result, "text/csv", "Report123.csv");
    }
