    public class Role : IdentityRole<string, UserRole> 
    { 
        //Any relevant properties
        public string Description { get; set; }
        public string MenuIcon { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }    
    }
