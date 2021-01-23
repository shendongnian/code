    static class Extensions
    {
      public static IEnumerable<BitSet> Choose(this BitSet b, int choose)
      {
        if (choose < 0) throw new InvalidOperationException();
        if (choose == 0) 
        { 
          // Choosing zero elements from any set gives the empty set.
          yield return BitSet.Empty; 
        }
        else if (b.Count() >= choose) 
        {
          // We are choosing at least one element from a set that has 
          // a first element. Get the first element, and the set
          // lacking the first element.
          int first = b.First();
          BitSet rest = b.Remove(first);
          // These are the permutations that contain the first element:
          foreach(BitSet r in rest.Choose(choose-1))
            yield return r.Add(first);
          // These are the permutations that do not contain the first element:
          foreach(BitSet r in rest.Choose(choose))
            yield return r;
        }
      }
    }
