    public class Employee : BaseObject
    {
        [ScriptIgnore]
        public string FirstName { get; set; }
        [ScriptIgnore]
        public string LastName { get; set; }
        [ScriptIgnore]
        public string Manager { get; set; }
    
        public string Login { get; set; }
        ...
    }
