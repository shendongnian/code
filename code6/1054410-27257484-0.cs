    [Table("Companys")]
    public class CompanyModel
    {
        // other properties and the rest of the code here
        public virtual AccountCircleModel AccountCircle { get; set; }
    }
    [Table("AccountCircles")]
    public class AccountCircleModel
    {
        // other properties and the rest of the code here
        public virtual CompanyModel Company { get; set; }
    
        public virtual ICollection<AccountCirleMemberModel> Member { get; set; }
    }
    [Table("AccountCircleMember")]
    public class AccountCirleMemberModel
    {
        // other properties and the rest of the code here
        public virtual AccountModel Account { get; set; }
        public virtual AccountCircleModel AccountCircle { get; set; }
    }
