    int[][] log = new int[][] {new int[]{1,2},new int[]{2,1},new int[]{1,3},new int[]{2,3},new int[]{3,4},new int[]{4,1}};
    List<Suspect> Suspects = new List<Suspect>(){new Suspect(){SuspectId =  1, Name = "Bob"},new Suspect(){SuspectId =  2, Name = "Frank"},new Suspect(){SuspectId =  3, Name = "Jimmy"},new Suspect(){SuspectId =  4, Name = "DrEvil"}};
					//order the contact pairs as  2 --> 1 is the same as 1 --> 2 
     var q = log.Select (x => x.OrderBy (o => o))
					// Put contact record into an object which we have an IComparable for
				.Select (s => new Contact(){A = s.ElementAt(0),B= s.ElementAt(1) })
					//Now eliminate the duplicates
    			.Distinct(new ContactComparer()) 
					//get the Name for contact A
    			.Join(Suspects, contactKey => contactKey.A, suspectKey => suspectKey.SuspectId,(c,s) => new Contact{A = c.A, AName = s.Name, B = c.B})
					//get the Name for contact B
    			.Join(Suspects, contactKey => contactKey.B, suspectKey => suspectKey.SuspectId,(c,s) => new Contact{A = c.A, AName = c.AName, B = c.B, BName = s.Name}) 
    			.ToList();
    //Classes that were used:
    public class Contact
	{
	
		public int A { get; set; }
		public String AName { get; set; }
		public int B { get; set; }
		public String BName { get; set; }
	
	}
    public class Suspect
    {
        public int SuspectId { get; set; }
        public String Name { get; set; }
    }
    //We will use this in the .Distinct() linq method, to find the (and remove) the duplicates	
    public class ContactComparer : IEqualityComparer<Contact>
    {        
        public bool Equals(Contact x, Contact y)
        {
    
            //Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether the id fields are equal. 
            return x.A == y.A && x.B == y.B;
        }
    	
    	  public int GetHashCode(Contact contact)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(contact, null)) return 0;
    
            //Get hash code for the Name field if it is not null. 
            long contactA = contact.A == null ? 0 : contact.A;
    		long contactB = contact.B == null ? 0 : contact.A;      
    
            //Calculate the hash code for the product. 
            return (int)((contactA + contactB) % int.MaxValue);
        }    	
    	
    }
