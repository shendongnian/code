    [DelimitedRecord(":")]
    public class ImportRecord
    {
        [FieldTrim(TrimMode.Both)]
        public string Key;
        [FieldTrim(TrimMode.Both)]
        public string Value;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ImportRecord>();
            string fileAsString = @"custID: 1732" + Environment.NewLine +
                                  @"name: Juan Perez" + Environment.NewLine +
                                  @"balance: 435.00" + Environment.NewLine +
                                  @"date: 11-05-2002" + Environment.NewLine;
    
            ImportRecord[] validRecords = engine.ReadString(fileAsString);
    
            var dictionary = validRecords.ToDictionary(r => r.Key, r => r.Value);
    
            Assert.AreEqual(dictionary["custID"], "1732");
            Assert.AreEqual(dictionary["name"], "Juan Perez");
            Assert.AreEqual(dictionary["balance"], "435.00");
            Assert.AreEqual(dictionary["date"], "11-05-2002");
    
            Console.ReadKey();
        }
    }
