    public class CreatePatientViewModel
    {
        public CreatePatientViewModel()
        {
            User = new User();
            Users = new List<User>();
            Devices = new List<SelectListItem>();
        }
    
        public User User { get; set; }
    
        public IList<SelectListItem> Devices { get; set; }
    
        public IList<User> Users { get; set; }
    }
