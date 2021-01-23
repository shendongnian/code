    using System.ComponentModel;
    namespace MyApp.ViewModels
    {
        public class AttributesFromAttribute : AttributeProviderAttribute
        {
            public AttributesFromAttribute(Type type, string property)
                : base(type.AssemblyQualifiedName, property)
            {
            }
            public T GetInheritedAttributeOfType<T>() where T : System.Attribute
            {
                Dictionary<string,object> attrs = Type.GetType(this.TypeName).GetProperty(this.PropertyName).GetCustomAttributes(true).ToDictionary(a => a.GetType().Name, a => a);
                return attrs.Values.OfType<T>().FirstOrDefault();
            }
        }
    }
