    public class Role
    {
        public RoleType Type { get; set; }
        public bool IsApproved { get; set; }
        //etc
    }
    public enum RoleType
    {
        Finance,
        HiringManager,
        //etc
    }
