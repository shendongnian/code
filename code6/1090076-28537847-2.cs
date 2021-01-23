    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class AutoRegistrationIncludeAssembliesAttribute
        : Attribute
    {
        public AutoRegistrationIncludeAssembliesAttribute(params string[] assemblies)
        {
            this.Assemblies = assemblies;
        }
        public string[] Assemblies { get; private set; }
    }
