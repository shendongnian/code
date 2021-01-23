        public enum ExportScope
        {
            Singleton,
            Transient
        }
        [AttributeUsage(AttributeTargets.Class)]
        public class ExportAttribute : Attribute
        {
            public ExportAttribute(Type serviceInterface, ExportScope scope = ExportScope.Singleton)
            {
                this.ServiceInterface = serviceInterface;
                this.Scope = scope;
            }
            public Type ServiceInterface { get; set; }
            public ExportScope Scope { get; set; }
        }
