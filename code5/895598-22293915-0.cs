    class EqualityComparer : IEqualityComparer<ClassName> {
    
      public Boolean Equals(ClassName x, ClassName y) {
        return Equals(x.Location, y.Location);
      }
    
      public Int32 GetHashCode(ClassName obj) {
        return obj.Location.GetHashCode();
      }
    
    }
