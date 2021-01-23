    public class Person : IEquatable<Person>
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
    
        public bool Equals(Person other)
        {
            return this.FirstName == other.FirstName
            && this.LastName == other.LastName;    
         }
    
         public override int GetHashCode()
         {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode;
         }
    }
