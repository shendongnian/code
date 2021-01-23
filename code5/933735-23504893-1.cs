    public class AlternatingCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new AlternatingBuilder());
        }
        private class AlternatingBuilder : ISpecimenBuilder
        {
            private bool createB;
            public object Create(object request, ISpecimenContext context)
            {
                var t = request as Type;
                if (t == null || t != typeof(Base))
                    return new NoSpecimen(request);
                if (this.createB)
                {
                    this.createB = false;
                    return context.Resolve(typeof(BaseImplB));
                }
                this.createB = true;
                return context.Resolve(typeof(BaseImplA));
            }
        }
    }
