    class Program
    {
        static void Main(string[] args)
        {
            var comma = @"one,""two, yo"",three";
            var tab = "one\ttwo, yo\tthee";
            var random = @"onelol""two, yo""lolthree";
    
            var parser = CreateParser(comma, ",");
            Console.WriteLine("Parsing " + comma);
            Dump(parser);
            Console.WriteLine();
            parser = CreateParser(tab, "\t");
            Console.WriteLine("Parsing " + tab);
            Dump(parser);
            Console.WriteLine();
            parser = CreateParser(random, "lol");
            Console.WriteLine("Parsing " + random);
            Dump(parser);
            Console.WriteLine();
            Console.ReadLine();
        }
    
        private static TextFieldParser CreateParser(string value, params string[] delims)
        {
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(ToStream(value));
            parser.Delimiters = delims;
            return parser;
        }
    
        private static void Dump(TextFieldParser parser)
        {
            while (!parser.EndOfData)
                foreach (var field in parser.ReadFields())
                    Console.WriteLine(field);
        }
    
        static Stream ToStream(string value)
        {
            return new MemoryStream(Encoding.Default.GetBytes(value));
        }
    }
