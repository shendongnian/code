    public class FooArg : ISpecimenBuilder
    {
        private readonly string value;
 
        public FooArg(string value)
        {
            this.value = value;
        }
 
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null)
                return new NoSpecimen(request);
            if (pi.Member.DeclaringType != typeof(Foo) ||
                pi.ParameterType != typeof(string) ||
                pi.Name != "str2")
                return new NoSpecimen(request);
 
            return value;
        }
    }
