    public class KeyNamePair : IComparable
    {
      public string Key { get; set; }
      public string Name { get; set; }
      public KeyNamePair(string key, string name)
      {
        this.Key = key;
        this.Name = name;
      }
      public int CompareTo(object obj)
      {
        var tmp = (KeyNamePair)obj;
        var newKey = int.Parse(tmp.Name.Split(' ')[1]);
        var oldKey = int.Parse(Name.Split(' ')[1]);
        if (oldKey > newKey)
          return (1);
        if (oldKey < newKey)
          return (-1);
        else
          return (0);
      }
    }
      List<KeyNamePair> list = new List<KeyNamePair>();
      list.Add(new KeyNamePair("1", "Day 1"));
      list.Add(new KeyNamePair("2", "Day 11"));
      list.Add(new KeyNamePair("4", "Day 5"));
      list.Add(new KeyNamePair("6", "Day 13"));
      list.Sort();
      foreach (var keyNamePair in list)
      {
        System.Console.Write(keyNamePair);
      }
