    class Program
    {
        static void Main(string[] args)
        {
            string file = Ask("What is the CSV file path? (full path)");
            string separator = Ask("What is the current separator? (; or ,)");
            var extract = new ExtractCsvIntoSql(file, separator);
            var sql = extract.Generate();
            Output(sql);
        }
        private static void Output(IEnumerable<string> sql)
        {
            foreach(var query in sql)
                Console.WriteLine(query);
            Console.WriteLine("*******************************************");
            Console.Write("END ");
            Console.ReadLine();
        }
        private static string Ask(string question)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine(question);
            Console.Write("= ");
            return Console.ReadLine();
        }
    }
