    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
        public override IEnumerable<object[]> GetData(System.Reflection.MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            var specimens = new List<object>();
            foreach (var p in methodUnderTest.GetParameters())
            {
                CustomizeFixture(p);
                if (p.ParameterType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IMock<>)))
                {
                    var freeze = new FreezingCustomization(p.ParameterType, p.ParameterType);
                    this.Fixture.Customize(freeze);
                }
                var specimen = Resolve(p);
                specimens.Add(specimen);
            }
            return new[] { specimens.ToArray() };
        }
        private void CustomizeFixture(ParameterInfo p)
        {
            var dummy = false;
            var customizeAttributes = p.GetCustomAttributes(typeof(CustomizeAttribute), dummy).OfType<CustomizeAttribute>();
            foreach (var ca in customizeAttributes)
            {
                var c = ca.GetCustomization(p);
                this.Fixture.Customize(c);
            }
        }
        private object Resolve(ParameterInfo p)
        {
            var context = new SpecimenContext(this.Fixture);
            return context.Resolve(p);
        }
