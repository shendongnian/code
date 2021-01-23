    public class LGCustDataViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        // and a bunch of other fields I have snipped for brevity.
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
        //The following can come from other 'models'
        public string Username { get; set; }
        public string Password { get; set; }
    }
