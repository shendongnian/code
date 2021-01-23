    using (var memoryStream = new MemoryStream())
    {
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter))
        {
            csvWriter.WriteRecords(data);
        } // The stream gets flushed here.
        memoryStream.Position = 0;
        return File(memoryStream, "text/csv", filename);
    }
