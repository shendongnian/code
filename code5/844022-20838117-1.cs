      public override Boolean Equals(Object obj) {
        // If obj is actually "this" then true
        if (Object.ReferenceEquals(this, obj))
          return true;
        // "as " is better the "is" + "(RatiosAVG)" 
        RatiosAVG other = obj as RatiosAVG;
        // obj is either null or not a RatiosAVG
        if (Object.ReferenceEquals(null, other))
          return false;
        // When you have 3 properties to compare, reflection is a bad idea 
        if (other.Value != Value)
          return false;
        else if (!String.Equals(other.Name, Name, StringComparison.Ordinal))
          return false;
        else if (!Object.Equals(other.Obj, Obj))
          return false;
        // Finally, dictionaries. If, the criterium is: 
        // "Dictionaries are considered being equal if and only 
        // if they have the same {key, value} pairs"
        // you can use Linq: SequenceEqual. 
        // Otherwise you should provide details for the dictionaries comparison
        if (!Enumerable.SequenceEqual(other.Dict1, Dict1))
          return false;
        else if (!Enumerable.SequenceEqual(other.Dict2, Dict2))
          return false;
        return true;
      }
      // Do not forget to override GetHashCode:
      public override int GetHashCode() {
        return Value; // <- Simplest version; probably you have to put more elaborated one
      }
