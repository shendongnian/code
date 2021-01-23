    public enum typeRoleEnum
    {
       country = 0,
       state = 1,
       town = 2
    }
    public class Role {
        public string name { get; set; }
        public typeRoleEnum type { get; set; }
    }
    public class Town: Role {}
    public class District : Role { }
    public class Country : Role { }
