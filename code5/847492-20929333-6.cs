    void ReadAndProcessFiles(string[] filePaths)
    {
        // Our thread-safe collection used for the handover.
        var lines = new BlockingCollection<string>();
        // Build the pipeline.
        var stage1 = Task.Run(() =>
        {
            try
            {
                foreach (var filePath in filePaths)
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Hand over to stage 2 and continue reading.
                            lines.Add(line);
                        }
                    }
                }
            }
            finally
            {
                lines.CompleteAdding();
            }
        });
        var stage2 = Task.Run(() =>
        {
            // Process lines on a ThreadPool thread
            // as soon as they become available.
            foreach (var line in lines.GetConsumingEnumerable())
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
            }
        });
        // Block until both tasks have completed.
        // This makes this method prone to deadlocking.
        // Consider using 'await Task.WhenAll' instead.
        Task.WaitAll(stage1, stage2);
    }
