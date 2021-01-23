    public class CreatePatientViewModel
    {
        public CreatePatientViewModel()
        {
            User = new User();
            Devices = new List<SelectListItem>();
        }
    
        public User User { get; set; }
    
        public IList<SelectListItem> Devices { get; set; }
    }
