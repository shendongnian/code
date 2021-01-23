    [DelimitedRecord(",")]
    public partial class Person : INotifyWrite<Person>
    {
        public string FirstName;
        public string LastName;
        [FieldOptional]
        public string Optional1;
        [FieldOptional]
        public string Optional2;
        [FieldOptional]
        public string Optional3;
        public void BeforeWrite(BeforeWriteEventArgs<Person> e)
        {
        }
        public void AfterWrite(AfterWriteEventArgs<Person> e)
        {
            // count the non-optional fields
            var numberOfNonOptionalFields = typeof(Person).GetFields()
                .Where(f => !f.GetCustomAttributes(false).Any(a => a is FieldOptionalAttribute))
                .Count();
            // take only the first n tokens
            e.RecordLine = String.Join(",", e.RecordLine.Split(',').Take(numberOfNonOptionalFields));
        }
    }      
    class Program
    {
        private static void Main(string[] args)
        {
            var engine = new FileHelperEngine<Person>();
            var export = engine.WriteString(
                         new Person[] { 
                           new Person() { 
                               FirstName = "Joe", 
                               LastName = "Bloggs", 
                               Optional1 = "Option 1", 
                               Optional2 = "Option 2", 
                               Optional3 = "Option 3" 
                           } 
                         });
            Assert.AreEqual("Joe,Bloggs" + Environment.NewLine, export);
            Console.WriteLine("Export was as expected");
            Console.ReadLine();
        }
    }
