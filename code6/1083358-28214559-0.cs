    String obj = "42";
    Parallel.ForEach(_ItemsDict, new ParallelOptions{ MaxDegreeOfParallelism = Environment.ProcessorCount},
                (i) =>
            {
                if (i.Key.StartsWith(obj))
                    bag.Add(new AssociatedItem() { associatedItemCode = i.Value });
            });
