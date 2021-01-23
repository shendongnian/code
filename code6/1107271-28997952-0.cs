    public class Staff : Member
    {
        public int ID{get;set;}
    
    }
    public class School 
    {
        public int ID{get;set;}
    
    }
    public class SchoolStaff 
    {
        public int ID{get;set;}
    
        [ForeignKey("School")]
        public int SchoolID {get;set;}
        [ForeignKey("SchoolID")]
        public virtual School School {get;set;}
        [ForeignKey("Staff")]
        public int StaffID {get;set;}
        [ForeignKey("StaffID")]
        public virtual Staff Staff {get;set;}
    
        virtual ICollection<SchoolStaffRole> Roles{get;set;}
    }
     public class SchoolStaffRole 
    {
        public int ID{get;set;}
    
        [ForeignKey("SchoolStaff")]
        public int SchoolStaffID {get;set;}
        [ForeignKey("SchoolStaffID")]
        public virtual SchoolStaff SchoolStaff {get;set;}
        [ForeignKey("SchoolRole")]
        public int SchoolRoleID {get;set;}
        [ForeignKey("SchoolRoleID")]
        public virtual SchoolRole SchoolRole {get;set;}
    
    }
