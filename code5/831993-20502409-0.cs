    public static void GetStats(ClrRuntime runtime)
    {
        ClrHeap heap = runtime.GetHeap();
        var stats = heap.EnumerateObjects()
                        .Select(obj => new 
                        {
                            Type = heap.GetObjectType(obj),
                            ObjectAddress = obj
                        })
                        .GroupBy(g => g.Type,
                                 g => g.Type.GetSize(g.ObjectAddress))
                        .Select(gr => new
                        {
                            Name = gr.Key.Name,
                            Count = gr.Count(),
                            Size = gr.Sum(x => (int)x)
                        })
                        .Where(t => !t.Name.StartsWith("System.") &&
                                    !t.Name.StartsWith("Microsoft.") &&
                                    !t.Name.Equals("Free"))
                        .ToList();
        Console.WriteLine("---------- Start ----------");
        foreach (var item in stats)
            Console.WriteLine("{0} {} {2}", item.Size, item.Count, item.Name);
    }
