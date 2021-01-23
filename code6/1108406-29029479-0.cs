    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(string version)
        {
            Version = version;
        }
        public string Version { get; set; }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DependentAttribute : Attribute
    {
        public string DependentOnMethod { get; set; }
        public string DependentOnVersion { get; set; }
    }
    [Dependent(DependentOnMethod = "OtherMethod", DependentOnVersion = "1")]
    public static void FirstMethod()
    {
    }
    [Version("1")]
    public static void OtherMethod()
    {
    }
