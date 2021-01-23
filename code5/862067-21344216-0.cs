    class MyEqualityComparer : EqualityComparer<FilterValueSet>
    {
      public override int GetHashCode(FilterValueSet obj) 
      {
        return obj.Id.GetHashCode();
      }
      public override bool Equals(T x, T y)
      {
        return x.Id.Equals(y.Id);
      }
    }
