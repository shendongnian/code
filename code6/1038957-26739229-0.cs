    using (var textWriter = Console.Out)
    using (var csvWriter = new CsvWriter(textWriter))
    {
        csvWriter.Configuration.RegisterClassMap<PersonClassMap>();
        csvWriter.WriteRecords(persons);
        textWriter.Flush();
    }
