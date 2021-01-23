    public class DomainStudent
    {
        public int Id { get; private set; } // prevent attempts to change Ids on domain entities
        public string Name { get; set; }
    }
    public class DomainStudentWithSecret
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string SecretData { get; set; }
    }
