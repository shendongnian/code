    var badGroups = collection.GroupBy(item => item.Key)
                              .Where(group => group.Count() > 1);
    foreach (var badGroup in badGroups)
    {
       Console.WriteLine("The key {0} appears {1} times.", badGroup.Key, badGroup.Count());
       forach (var badItem in badGroup)
       {
          Console.WriteLine(badItem);
       }
    }
    var goodItems = collection.GroupBy(item => item.Key)
                              .Where(group => group.Count() == 1)
                              .SelectMany(group => group);
    foreach (var goodItem in goodItems)
    {
       Console.WriteLine("The key {0} appears exactly once.", goodItem.Key);
    }
    var dictionary = goodItems.ToDictionary(item => item.Key);
