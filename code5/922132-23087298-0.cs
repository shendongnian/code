    public class KeyClass 
    {
       public readonly string key;
       
       public KeyClass(string key)
       {
          this.key = key;
       }
       public override bool Equals(object other)
       {
           if (other == null)
             return false;
           
           // Casting object other to type KeyClass
           KeyClass obj = other as KeyClass;
           if (obj == null)
             return false;
            return this.key == other.key;
       }
       public override int GetHashCode()
       {
            return this.key.GetHashCode();
       }
    }
