    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Property | AttributeTargets.Field)]
    public class Serialise : Attribute, IAspectProvider, IValidableAnnotation
    {
        public string ApplyToProperty { get; set; }
        public string Name { get; set; }
        public bool CompileTimeValidate(object target)
        {
            return false;
        }
        
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            // Code that introduces a different attribute
        }
    }
