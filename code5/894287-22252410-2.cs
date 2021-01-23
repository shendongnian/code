    using (var stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (CsvWriter csv = new CsvWriter(writer)) {
      csv.Configuration.With(x => {
        x.AutoMap<UserModel>();
        x.RegisterClassMap<UserModelCsvMapper>();  
      });            
      csv.WriteRecords(reply.Users)
      writer.Flush();
      return File(stream.ToArray(), "text/csv", "Users.csv");
    }
