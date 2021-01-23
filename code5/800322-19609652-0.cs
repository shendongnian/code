        namespace SuccessEd.Data.Model
    {
        public class Contact
        {
      
    
     public Contact () 
               {
                  AddressList = new List<Address>();
               }
            public int ContactId { get; set; }
    
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            public virtual ICollection<Address> Addresses { get; set; }
        }
    }
