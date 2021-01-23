    public class ApplicationUser : IdentityUser
    {   //You can add extra properties in if you want
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Or add a link to your customer table
        public Customer CustomerDetails { get; set; }
    }
