    public class NameViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        // other properties
        //...
    }
    public class PersonViewModel
    {
        public IList<NameViewModel> Names { get; set; }
        [Required]
        public int? Primary { get; set; }
        // other properties
        //...
    }
