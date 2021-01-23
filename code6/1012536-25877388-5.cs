              List<Item> items = new List<Item>(8000);
            //add to list
            var dictionary = new ConcurrentDictionary<int, Dictionary<int, int>>();//thread-safe dictionary
            var readOnlyItems = items.AsReadOnly();// if you sure you wouldn't modify collection, feel free use items directly
            Parallel.ForEach(readOnlyItems, item =>
            {
                dictionary[item.index] = Relatedness2(readOnlyItems, item);
            });
