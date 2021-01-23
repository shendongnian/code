    Console.Write("Number of store groups: ");
    int numberOfStoreGroups = int.Parse(Console.ReadLine());
    int[][] stores = new int[numberOfStoreGroups][];
    // Now loop through each group
    for (int i = 0;i < numberOfStoreGroups;++i)
    {
        Console.Write("Number of stores in group {0}: ", i + 1);
        int groupSize = int.Parse(Console.ReadLine());
        stores[i] = new int[groupSize];
        // Now loop through each store in the group
        for (int j = 0;j < groupSize;++j)
        {
            Console.Write("Store number {0}: ", j + 1);
            stores[i][j] = int.Parse(Console.ReadLine());
        }
    }
