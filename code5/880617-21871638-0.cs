    var data = from row in IdComLog.Data.Formats.Csv.ReadRecords("inputFile.csv")
               select new[]{ row[1].Value, row[2].Value, row[5].Value }
    
    var sw = new StringWriter();
    IdComLog.Data.Formats.Csv.Write(sw, data);
    string requiredCsvContent = sw.ToString();
