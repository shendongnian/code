    public class Person
    {
        public int id {get;set;}
        public string name {get;set;}
    
        public override bool Equals(object obj)
        {
            Person p2 = obj as Person;
            if (object.ReferenceEquals(null, p2)) return false;
            return id == p2.id;
        }
    
        public static bool operator ==(Person p1, Person p2)
        {
            if (object.ReferenceEquals(null, p1))
                return object.ReferenceEquals(null, p2);
            else if (object.ReferenceEquals(null, p2))
                return false;
            return p1.Equals(p2);
        }
    
        public static bool operator !=(Person p1, Person p2)
        {
            if (object.ReferenceEquals(null, p1))
                return !object.ReferenceEquals(null, p2);
            else if (object.ReferenceEquals(null, p2))
                return true;
            return !p1.Equals(p2);
        }
    
        public override int  GetHashCode()
        {
            return id ;
        }
    }
