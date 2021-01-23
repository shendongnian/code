    public class GuestListViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // And the rest of the fields
        //These fields are new
        public string LastNameSort { get; set; }
        public string FirstNameSort { get; set; }
        public List<Guest> Guests { get; set; }
    }
