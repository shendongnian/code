    using (var csv = new CsvReader(r, false, csvParserConfiguration.ColumnSeparator, '"', '"', '#', ValueTrimmingOptions.None))
    {            
     // Read lines
     while (csv.ReadNextRecord())
     {
      contactNumberList.Add[7];
     }
    }
