    public class Customer
    {
        /* other members */
        public string ContactName 
        { 
            get 
            {
                string name = null;
                if (CustomerContacts != null && CustomerContacts.Any()) 
                {
                    name = CustomerContacts.First().ContactName;
                }
                
                return name;
            }
        }
        
        public string ContactTel
        {
            get 
            {
                string tel = null;
                
                
                if (CustomerContacts != null && CustomerContacts.Any()) 
                {
                    tel = CustomerContacts.First().ContactTel;
                }
                return tel;
            }
        }
        
    }
