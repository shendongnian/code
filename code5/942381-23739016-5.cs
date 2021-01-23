        public class Tender
        {
            public int TenderId { get;set;} 
            public int UserId {get;set;}  //this links to the userid in the UserProfiles table
            public virtual ICollection<Project> Projects {get;set;} 
        }
    
        public class Project
        {
            public int ProjectId {get;set;}
            public int TenderId {get;set;}
    
            public virtual Tender Tender {get;set;}
            public virtual ICollection<Supplier> Suppliers {get;set;}
            public virtual ICollection<Requirement> Requirements {get;set;}
        }
    
        public class Supplier
        {  
            public int SupplierId {get;set;}
         
            public virtual ICollection<Project> Projects {get;set;}
        }
    
        public class Requirement
        {
             public int RequirmentId {get;set;}
             public int ProjectId {get;set;}
    
             public virtual Project Project {get;set;}
        }
