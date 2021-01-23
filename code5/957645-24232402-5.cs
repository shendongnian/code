    using Iesi.Collections.Generic;
    public class Role
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<Permission> Permissions { get; set; }
    
        public Role()
        {
          //Permissions = new HashSet<Permission>();
            Permissions = new HashedSet<Permission>();
        }
    }
