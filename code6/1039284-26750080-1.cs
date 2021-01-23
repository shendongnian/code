                Console.WriteLine("Your valid entries were: ");
                Console.WriteLine(string.Join(Environment.NewLine, validEntries));
                Console.WriteLine();
                Console.WriteLine("Your invalid entries were: ");
                Console.WriteLine(string.Join(Environment.NewLine, invalidEntries));
                Console.WriteLine();
                Console.WriteLine("Min:{0}  Max:{1}",validEntries.Min(),validEntries.Max());
