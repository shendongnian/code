    public class AccUserRole
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public virtual List<AccAdGroup> Groups { get; set; }
        public virtual List<AccScreen> Screens { get; set; }
    }
    
    public class AccAdGroup
    {
        public long Id { get; set; }
        public string AdIdent { get; set; }
        public virtual List<AccUserRole> Roles { get; set; }
    }
    
    
    
    public class AccScreen
    {
        public long Id { get; set; }
        public string ScreenIdent { get; set; }
        public virtual List<AccUserRole> Roles { get; set; }
    }
