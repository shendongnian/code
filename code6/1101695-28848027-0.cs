    class Program
    {
        static void Main(string[] args)
        {
            // dummy test data
            var originalAllPersonRecords = new Person[]
            {
                new Person { FirstName = "John", LastName = "Lee", Optional2 = "title" },
            };//This will only get the FirstName,LastName,Optional2. No result for Optional1 and Optional3
            var allPersonRecords = from p in originalAllPersonRecords select new OutputPerson{ FirstName = p.FirstName, LastName = p.LastName, Optional2 = p.Optional2 };
            FileHelperEngine enginePerson = new FileHelperEngine(typeof(OutputPerson));
            string fileName = "Wherever you want the file to go";
            enginePerson.AppendToFile(fileName, allPersonRecords); //Write the records to the file
            //Current Output looks like this:John      Lee            title     
            //The output which I want is:John      Lee       title
        }
    }
    //New class added representing the output format
    [FixedLengthRecord(FixedMode.ExactLength)]
    class OutputPerson
    {
        [FieldFixedLength(10)]
        public string FirstName;
        [FieldFixedLength(10)]
        public string LastName;
        [FieldOptional]
        [FieldFixedLength(5)]
        public string Optional2;
    }
    [FixedLengthRecord(FixedMode.ExactLength)]
    class Person
    {
        [FieldFixedLength(10)]
        public string FirstName;
        [FieldFixedLength(10)]
        public string LastName;
        [FieldOptional]
        [FieldFixedLength(5)]
        public string Optional1;
        [FieldOptional]
        [FieldFixedLength(5)]
        public string Optional2;
        [FieldOptional]
        [FieldFixedLength(5)]
        public string Optional3;
    }
