        public Int32 ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        
        public Int32 RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
    public class User {
        public Int32 Id { get; set; }
        public String Username { get; set; }
        public String UserImagePath { get; set; }
        public String Password { get; set; }
        
        public virtual ISet<Role> Roles { get; set; }
        
        public User(String username, String password) : this() {
            this.Username = username;
            this.Password = password;
        }
        protected User() { 
            this.Roles = new HashSet<Role>();
        }
    }
    public class Role {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public virtual ISet<User> Users { get; set; }
        public virtual ISet<RoleResourceActivity> RoleResourceActivities { get; set; }
        public Role(String name) : this() { 
            this.Name = name;
        }
        protected Role() {
            this.Users = new HashSet<User>();
            this.RoleResourceActivities = new HashSet<RoleResourceActivity>();
        }
    }
    public class Resource {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public virtual ISet<RoleResourceActivity> RoleResourceActivities { get; set; }
        public Resource(String name) : this() {
            this.Name = name;
        }
        protected Resource() {
            this.RoleResourceActivities = new HashSet<RoleResourceActivity>();
        }
    }
    public class Activity {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public virtual ISet<RoleResourceActivity> RoleResourceActivities { get; set; }
        public Activity(String name) : this() {
            this.Name = name;
        }
        protected Activity() {
		    this.RoleResourceActivities = new HashSet<RoleResourceActivity>();
	    }
    }
