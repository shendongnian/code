    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DestinationAttribute : Attribute
    {
        public DestinationAttribute() { this.Path = @"\Home"; }
        public string Path { get; set; }
    }
    [Destination(Path = @"\ManagerHome")]
    public class Manager : Role { }
    string GetDestination(Role role)
    {
        var destination = role.GetType().GetCustomAttributes(typeof(DestinationAttribute), true).FirstOrDefault();
        if (destination != null)
            return destination.Path;
        return @"\Home";
    }
