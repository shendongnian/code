    List<int> temp = new List<int>();
    temp.Add(1);
    temp.Add(2);
    temp.Add(3);
    temp.Add(4);
    List<int> ints = temp;
    Func<int, bool> check = x => x != 2;
    IEnumerator<int> enumerator = ints.Where(check).GetEnumerator();
    try {
      while (enumerator.MoveNext()) {
        int i = enumerator.Current;
        Console.WriteLine(i);
      }
    } finally {
      if (enumerator != null) {
        enumerator.Dispose();
      }
    }
