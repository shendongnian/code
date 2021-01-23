    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            [
                {
                    ""gates"": 1,
                    ""truthtable"": [ false, true ]
                },
                {
                    ""gates"": 2,
                    ""truthtable"": [ [ false, false ], [ false, true ] ]
                }
            ]";
            List<Chip> chips = JsonConvert.DeserializeObject<List<Chip>>(json,
                                                             new ChipConverter());
            foreach (Chip c in chips)
            {
                Console.WriteLine("gates: " + c.Gates);
                foreach (List<bool> list in c.TruthTable)
                {
                    Console.WriteLine(string.Join(", ",
                        list.Select(b => b.ToString()).ToArray()));
                }
                Console.WriteLine();
            }
        }
    }
