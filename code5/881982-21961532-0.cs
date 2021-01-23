    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class UnityNamedInstanceAttribute : Attribute
    {
        private readonly string instanceName;
        public UnityNamedInstanceAttribute(string instanceName)
        {
            this.instanceName = instanceName;
        }
        public string InstanceName
        {
            get { return this.instanceName; }
        }
    }
