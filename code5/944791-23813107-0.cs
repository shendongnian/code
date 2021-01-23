    public class EmployeeDetailModel
    {
        public WebApplication2.Entities.Employee Employee { get; set; }
        public WebApplication2.Entities.MovieEmployee MovieEmployee { get; set; }
        public IEnumerable<WebApplication2.Entities.Role> Roles { get; set; }
        public int NewRoleId { get; set; }
    
        public EmployeeDetailModel()
        {
            Roles = new List<WebApplication2.Entities.Role>();
        }
    }
