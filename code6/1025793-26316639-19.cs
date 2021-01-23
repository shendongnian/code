    class Program
    {
      static void Main()
      {
        BitSet b = BitSet.Empty.Add(1).Add(2).Add(3).Add(4).Add(5).Add(6).Add(7);
        foreach(BitSet result in b.Choose(3))
          Console.WriteLine(result);
      }
    }
