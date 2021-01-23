    [DelimitedRecord(":")]
    [IgnoreEmptyLines()]
    public class ImportRecord
    {
        [FieldTrim(TrimMode.Both)]
        public string Key;
        [FieldTrim(TrimMode.Both)]
        public string Value;
    }
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Balance { get; set; }
        public string Date { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ImportRecord>();
            string fileAsString =
    @"custID: 1732
    name: Juan Perez
    balance: 435.00
    date: 11-05-2002
    
    custID: 554
    name: Pedro Gomez
    balance: 12342.30
    date: 06-02-2004";
            ImportRecord[] validRecords = engine.ReadString(fileAsString);
            var customers = validRecords
                .Batch(4, x => x.ToDictionary(r => r.Key, r => r.Value))
                .Select(dictionary => new Customer()
                    {
                        Id = dictionary["custID"],
                        Name = dictionary["name"],
                        Balance = dictionary["balance"],
                        Date = dictionary["date"]
                    }).ToList();
                      
            Customer customer1 = customers[0];
            Assert.AreEqual(customer1.Id, "1732");
            Assert.AreEqual(customer1.Name, "Juan Perez");
            Assert.AreEqual(customer1.Balance, "435.00");
            Assert.AreEqual(customer1.Date, "11-05-2002");
            Customer customer2 = customers[1];
            Assert.AreEqual(customer2.Id, "554");
            Assert.AreEqual(customer2.Name, "Pedro Gomez");
            Assert.AreEqual(customer2.Balance, "12342.30");
            Assert.AreEqual(customer2.Date, "06-02-2004");
            Console.WriteLine("All OK");
            Console.ReadKey();
        }
    }
