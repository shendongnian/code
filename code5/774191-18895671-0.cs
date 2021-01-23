    [Table("PersonRolesXRef")]
    public class PersonRoles {
        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
    }
    
