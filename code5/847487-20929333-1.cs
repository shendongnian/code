        var stage2 = Task.Run(() =>
        {
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
            Parallel.ForEach(lines.GetConsumingEnumerable(), parallelOptions, line =>
            {
                String pattern = "\\s{4,}";
                foreach (String trace in Regex.Split(line, pattern))
                {
                    if (trace != String.Empty)
                    {
                        String[] details = Regex.Split(trace, "\\s+");
                        Instruction instruction = new Instruction(details[0],
                            int.Parse(details[1]),
                            int.Parse(details[2]));
                        Console.WriteLine("computing...");
                        instructions.Add(instruction);
                    }
                }
            });
        });
