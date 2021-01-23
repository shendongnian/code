    using (var textWriter = File.CreateText("MyCsvLol.csv"))
        using (var writer = new CsvWriter(textWriter))
        {
            foreach (var charge in charges)
            {
                writer.WriteRecord(charge);
            }       
        }
    
     HttpContext.Current.Response.Write(File.ReadAllText("MyCsvLol.csv"));
     HttpContext.Current.Response.End();
