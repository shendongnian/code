     Dictionary<int, int> ItemCount = new Dictionary<int, int>();
     int[] items = { 2, 3, 4, 3, 4, 2, 4, 2, 4 };
     foreach (int item in items)
     {
        if (ItemCount.ContainsKey(item))
        {
             ItemCount[item]++;
        }
        else {
            ItemCount.Add(item,1);
        }
     }
      Console.WriteLine("A|B");
      foreach (KeyValuePair<int,int> res in ItemCount)
      {
          Console.WriteLine(res.Key +"|"+res.Value);
      }
