    Execute(() => {
        using(ItemCollection.DeferRefresh()) {
            foreach (Item item in compiledList)
            {
                ItemCollection.Add(item);
            }
        }
    });
