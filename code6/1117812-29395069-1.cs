    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DataCoreMemberAttribute : Attribute
    {
        public string MemberName { get; set; }
    }
