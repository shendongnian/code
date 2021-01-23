    public class GenericArgCustomization<T> : ISpecimenBuilder
    {
        private readonly string name;
        private readonly T value;
        public GenericArgCustomization(string name, T value)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Name is required", "name");
            this.name = name;
            this.value = value;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null)
                return new NoSpecimen(request);
            if (pi.ParameterType != typeof(T) || pi.Name != this.name)
                return new NoSpecimen(request);
            return this.value;
        }
    }
