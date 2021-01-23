    public class UserViewModel {
        public User User { get; set; }
        public int PrivelegesId { get; set; }
        public IEnumerable<PrivilegeGroup> PrivilegesGroups { get; set; }
        public IEnumerable<Company> UserCompanies { get; set; }
    }
