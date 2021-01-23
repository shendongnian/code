    for (var i = 0; i < Processor.HardwareCores.Length; ++i)
    {
        Console.WriteLine("Hardware Core {0} has logical cores {1}", i,
            string.Join(", ", Processor.HardwareCores[i].LogicalCores));
    }
    Console.WriteLine("All logical cores: " + string.Join(", ", Processor.LogicalCores));
    Console.WriteLine("Current Logical Core is " + Processor.CurrentLogicalCore);
