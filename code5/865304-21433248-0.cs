    public class FooComparer : IEqualityComparer<Foo>
    {
          public bool Equals(Foo o1, Foo o2)
          {
              return o1.key == o2.key;
          }
    
          public int GetHashCode(Foo obj)
          {
              return obj.key.GetHashCode();
          }
    }
    resultList = L1.Join(L2.Select(m => m).Distinct(new FooComparer()).ToList(), f1 => f1.key, f2 => f2.key, (f1, f2) => Merge(f1, f2)
                            ).ToList());
