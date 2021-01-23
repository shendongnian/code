            string part1 = r.Substring(0, r.IndexOf(@"_"));
            string part2 = r.Substring(r.IndexOf(@"."), 5);
            Console.WriteLine(part1);
            Console.WriteLine(part2);
            Console.WriteLine(part1 + part2);
