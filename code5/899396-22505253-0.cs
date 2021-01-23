    public class Role {
        public virtual IList<LdapObjects> LdapGroups {
            get;
            set;
        }
        // Transient
        public virtual int[] LdapGroupsSelected {
            get;
            set;
        }
    }
