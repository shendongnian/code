    static void Main(string[] args)
    {
        var records = CSVreader<Record>("TextFile1.csv");            
    }
    public class Record
    {
        public string Email { get; set; }
    }
    public class CustomClassMap : CsvHelper.Configuration.CsvClassMap<Record>
    {
        public override void CreateMap()
        {
            Map(m => m.Email);
        }
    }
    public static IEnumerable<T> CSVreader<T>(string fileName)
    {
        using (var fileReader = File.OpenText(fileName))
        using (var csvReader = new CsvHelper.CsvReader(fileReader))
        { 
            csvReader.Configuration.IsHeaderCaseSensitive = false;
            csvReader.Configuration.RegisterClassMap<CustomClassMap>();
            while (csvReader.Read())
            {
                var record = csvReader.GetRecord<T>();
                yield return record;
            }
        }
    }
