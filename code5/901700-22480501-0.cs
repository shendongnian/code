    public class eq : IEquatable<eq> {
        public string s1;
        public string s2;
    
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            eq o = obj as eq;
            if (o == null) return false;
            return Equals(o);
        }
    
        public bool Equals(eq o)
        {
            if (s1==o.s1 && s2==o.s2)
                return true;
            return false;
        }
    
        public override int GetHashCode() {
          if (String.IsNullOrEmpty(s1))
            if (String.IsNullOrEmpty(s2))
              return 0;
            else
              return s2.GetHashCode();
          else if (String.IsNullOrEmpty(s2))
            return s1.GetHashCode();
    
          // Typical trick: xoring hash codes 
          return s1.GetHashCode() ^ s2.GetHashCode();      
        }
