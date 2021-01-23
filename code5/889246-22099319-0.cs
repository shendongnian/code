    public class Money
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class SomeClass
    {
        public SomeClass() { }
        [XmlIgnore]
        public Money WrappedMoney { get; set; }
        [XmlAttribute]
        public string moneyValue
        {
            get
            {
                return String.Format("{0:.##}{1}", WrappedMoney.Amount, WrappedMoney.CurrencyCode);
            }
        }
    }
    public class ParentClass
    {
        public SomeClass SomeClass {get; set;}
    }
    class Program
    {
        public static int Main(string[] args)
        {
            var parent = new ParentClass
            {
                SomeClass = new SomeClass
                {
                    WrappedMoney = new Money { Amount = 1.25M, CurrencyCode = "USD" }
                }
            };
            var serializer = new XmlSerializer(typeof(ParentClass));
            using (var writer = new StreamWriter("output.xml"))
            {
                serializer.Serialize(writer, parent);
            }
            return 0;
        }
    }
