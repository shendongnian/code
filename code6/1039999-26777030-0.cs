    public class NonRequestScopedParameter : Ninject.Parameters.IParameter
    {
        public bool Equals(IParameter other)
        {
            if (other == null)
            {
                return false;
            }
            return other is NonRequestScopedParameter;
        }
        public object GetValue(IContext context, ITarget target)
        {
            throw new NotSupportedException("this parameter does not provide a value");
        }
        public string Name
        {
            get { return typeof(NonRequestScopedParameter).Name; }
        }
        // this is very important
        public bool ShouldInherit
        {
            get { return true; }
        }
    }
