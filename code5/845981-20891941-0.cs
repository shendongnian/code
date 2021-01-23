    public class PersonViewModel
    {
        public PersonViewModel()
        {
            this.Names = new List<NameViewModel>();
        }
    
        public IList<NameViewModel> Names { get; set; }
    
    }
    
    public class NameViewModel
    {
        public NameViewModel()
        {
            this.IsPrimary = false;
        }
    
        public int ID { get; set; }
    
        public string FirstName { get; set; }
            
        public string LastName { get; set; }
            
        public string MiddleName { get; set; }
    
        public bool IsPrimary { get; set; }
    
        public string FullName
        {
            get
            {
                return string.Format("{0}{1} {2}",
                                    this.FirstName,
                                    !string.IsNullOrWhiteSpace(this.MiddleName) ? " " + this.MiddleName : "",
                                    this.LastName);
            }
        }
