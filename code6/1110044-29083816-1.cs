    var obj1 = new Item {Id = 1, Data = 
        new Dictionary<string, int> {{"1", 11}, {"2", 12}, {"3", 13}}};
    var obj2 = new Item {Id = 2, Data = 
        new Dictionary<string, int> {{"1", 21}, {"2", 22}, {"3", 23}}};
    var obj3 = new Item {Id = 3, Data = 
        new Dictionary<string, int> {{"1", 31}, {"2", 32}, {"3", 33}}};
    var obj4 = new Item {Id = 1, Data = 
        new Dictionary<string, int> {{"1", 41}, {"2", 42}, {"3", 43}}};
    var obj5 = new Item {Id = 2, Data = 
        new Dictionary<string, int> {{"1", 51}, {"2", 52}, {"3", 53}}};
    var obj6 = new Item {Id = 3, Data = 
        new Dictionary<string, int> {{"1", 61}, {"2", 62}, {"3", 63}}};
    List<Item> lst1 = new List<Item>();
    lst1.Add(obj1);
    lst1.Add(obj2);
    lst1.Add(obj3);
    List<Item> lst2 = new List<Item>();
    lst2.Add(obj4);
    lst2.Add(obj5);
    lst2.Add(obj6);
    // Add up as many lists of items that you want
    var result = AddItems(new List<List<Item>> {lst1, lst2});
