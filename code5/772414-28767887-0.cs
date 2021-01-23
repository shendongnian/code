    public class AutoPropertyDataAttribute : DataAttribute
    {
        private readonly string _propertyName;
        private readonly Func<IFixture> _createFixture;
        public AutoPropertyDataAttribute(string propertyName)
            : this(propertyName, () => new Fixture())
        { }
        protected AutoPropertyDataAttribute(string propertyName, Func<IFixture> createFixture)
        {
            _propertyName = propertyName;
            _createFixture = createFixture;
        }
        public Type PropertyHost { get; set; }
        private IEnumerable<object[]> GetAllParameterObjects(MethodInfo methodUnderTest)
        {
            var type = PropertyHost ?? methodUnderTest.DeclaringType;
            var property = type.GetProperty(_propertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (property == null)
                throw new ArgumentException(string.Format("Could not find public static property {0} on {1}", _propertyName, type.FullName));
            var obj = property.GetValue(null, null);
            if (obj == null)
                return null;
            var enumerable = obj as IEnumerable<object[]>;
            if (enumerable != null)
                return enumerable;
            var singleEnumerable = obj as IEnumerable<object>;
            if (singleEnumerable != null)
                return singleEnumerable.Select(x => new[] {x});
            throw new ArgumentException(string.Format("Property {0} on {1} did not return IEnumerable<object[]>", _propertyName, type.FullName));
        }
        private object[] GetObjects(object[] parameterized, ParameterInfo[] parameters, IFixture fixture)
        {
            var result = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i < parameterized.Length)
                    result[i] = parameterized[i];
                else
                    result[i] = CustomizeAndCreate(fixture, parameters[i]);
            }
            return result;
        }
        private object CustomizeAndCreate(IFixture fixture, ParameterInfo p)
        {
            var customizations = p.GetCustomAttributes(typeof (CustomizeAttribute), false)
                .OfType<CustomizeAttribute>()
                .Select(attr => attr.GetCustomization(p));
            foreach (var c in customizations)
            {
                fixture.Customize(c);
            }
            var context = new SpecimenContext(fixture);
            return context.Resolve(p);
        }
        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            foreach (var values in GetAllParameterObjects(methodUnderTest))
            {
                yield return GetObjects(values, methodUnderTest.GetParameters(), _createFixture());
            }
        }
    }
