    public class PersonViewModel
    {
        public PersonViewModel()
        {
            this.Names = new List<NameViewModel>();
        }
    
        public IList<NameViewModel> Names { get; set; }
    
        public int PrimaryName { get; set; }
    }
