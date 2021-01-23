    public void CountChar() {
      String s = Ipstring();
      foreach (var g in s.GroupBy(c => c)) {
        Console.WriteLine("{0} : {1}", g.Key, g.Count());
      }
    }
