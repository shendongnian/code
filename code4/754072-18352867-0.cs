    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;
        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();
            return new NoSpecimen(request);
        }
    }
