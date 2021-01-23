    var reader = new CsvReader(sr);
    do
    {
        reader.Read();                   
        var record=new DataRecord();
    
        record.TimeOfDay=reader.ReadField<string>("Time of Day");
        record.ProcesName=reader.ReadField<string>("Process Name");
        record.PID=reader.ReadField<string>("PID");
        record.Operation=reader.ReadField<string>("Operation");
        record.Path=reader.ReadField<string>("Path");
        record.Result=reader.ReadField<string>("Result");
        record.Detail=reader.ReadField<string>("Detail");
        record.ImagePath=reader.ReadField<string>("Image Path");
    
    } while (!reader.IsRecordEmpty());
