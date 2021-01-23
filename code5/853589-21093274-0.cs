        static void Main(string[] args)
        {
            var records = (from l in File.ReadAllLines("Tab.txt")
                           let pieces = l.Split('\t')
                           select new { Col1 = pieces[0], Col2 = pieces[1], Col3 = pieces[2] }).OrderBy(c => c.Col3);
            foreach(var r in records)
                Console.WriteLine("{0}, {1}, {2}", r.Col1, r.Col2, r.Col3);
            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
