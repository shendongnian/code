    public class ObjectWithDescriptionAndStatus
    {
        public string Description;
        public string Status;
    }
    
    public class ObjectWithResultAndGroup
    {
        public bool Result;
        public string Group;
    }
    
    public class MyObject
    {
        public ObjectWithDescriptionAndStatus AVRunning;
        public ObjectWithDescriptionAndStatus CorrectOU;
        public ObjectWithResultAndGroup RoleAdGroups;
        public IList<ObjectWithResultAndGroup> DefaultAdGroups;
    }
