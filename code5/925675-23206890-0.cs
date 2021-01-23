    //list.Add(new Item<int>());
    Item item1 = new Item<int>();   // implicit conversion from Item<int> to Item
    list.Add(item1);
    //list.Add(new Item<double>());
    Item item2 = new Item<double>();
    list.Add(item2);
