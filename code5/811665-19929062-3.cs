    var slots = new SlotCollection(0.02);
    slots.Add(inputs);
    // Spit out the desired user output.
    foreach (var kvp in slots)
    {
        Console.WriteLine(kvp.Key + " " + kvp.Value);
    }
    Console.WriteLine();
    // Output a more in depth view of the data distribution.
    foreach (var slot in slots.Slots)
    {
        Console.WriteLine(slot);
        foreach (var value in slot.Values)
        {
            Console.WriteLine("\t" + value);
        }
        Console.WriteLine();
    }
