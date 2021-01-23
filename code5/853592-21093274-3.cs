        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Tab.txt");
            int start = 1; // set to zero, if no header
            var records = (from i in Enumerable.Range(start, lines.Length - 1)
                           let pieces = lines[i].Split('\t')
                           select new { Col1 = pieces[0], Col2 = pieces[1], Col3 = pieces[2] })
                           .GroupBy(c => c.Col1 + c.Col2 + c.Col3)
                           .Select(gr => gr.First())
                           .OrderBy(c => c.Col3);
            foreach (var r in records)
                Console.WriteLine("{0}, {1}, {2}", r.Col1, r.Col2, r.Col3);
            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
