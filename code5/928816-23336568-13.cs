    public class LGCustDataViewModel
    {
        // ------------- this is from LGCustData model
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        // ------------- this is from LGCustData model
        // ------------- this is just manipulation of data within this model
        public string namesCombined 
        { 
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int theAge 
        { 
            get
            {
                 return -1;
                 //DateTime.Now.Year - BirthDate.Year
            }
        }
        // ------------- this is just manipulation of data within this model
        // ------------- this came from another model, like LoginAccount
        public string Username { get; set; }
        public string Password { get; set; }
        // ------------- this came from another model, like LoginAccount
    }
