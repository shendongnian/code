    var reader = new CsvReader(sr);
    do
    {
        reader.Read();                   
        var record=new DataRecord();
    
        record.TimeOfDay=reader.GetField<string>("Time of Day");
        record.ProcessName=reader.GetField<string>("Process Name");
        record.PID=reader.GetField<string>("PID");
        record.Operation=reader.GetField<string>("Operation");
        record.Path=reader.GetField<string>("Path");
        record.Result=reader.GetField<string>("Result");
        record.Detail=reader.GetField<string>("Detail");
        record.ImagePath=reader.GetField<string>("Image Path");
    
    } while (!reader.IsRecordEmpty());
