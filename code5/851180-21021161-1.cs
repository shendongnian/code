    public class Person{
    	public int ID{ get; set;}
    	public int Age{ get; set;}
    	public string Name{ get; set;}
    	public string Group{ get; set;}
    
    	// constructors and other class specific 
    	// methods come here.
    }
    
    public class PersonComparer : IEqualityComparer<Person>
    {
        public int GetHashCode(Person p)
        {
            if (p == null)
            {
                return 0;
            }
    		
    		// you can put any custom hashcode generation here.
            return p.Name.GetHashCode() 
    					^ p.Age.GetHashCode 
    					^ p.Group.GetHashCode();
    		
        }
    
        public bool Equals(Person p1, Person p1) {
            if (object.ReferenceEquals(p1, p2)) {
                return true;
            }
            if (
    			object.ReferenceEquals(p1, null) ||
                object.ReferenceEquals(p2, null)
    		) {
                return false;
            }
            return p1.Name == p2.Name &&
    				p1.Age == p2.Age &&
    				p1.Group == p2.Group;	// consider equal ordinal ignore case
        }
    }
