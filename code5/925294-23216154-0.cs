    var csv = new CsvWriter(writer);
    csv.Configuration.Encoding = Encoding.UTF8;
    foreach (var value in valuess)
    {
         csv.WriteRecord(value);
    }
    writer.Close();
