    public class MyContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            // if the type is a Thing and has child properties that are things...
            if (typeof(Thing).IsAssignableFrom(type) &&
                properties.Any(p => typeof(Thing).IsAssignableFrom(p.PropertyType)))
            {
                // grab only the properties that are NOT a Thing
                properties = properties
                    .Where(p => !typeof(Thing).IsAssignableFrom(p.PropertyType))
                    .ToList();
                // Create a virtual "things" property to group the remaining properties
                // into; associate the new property with a ValueProvider that will do
                // the actual grouping when the containing object is serialized
                properties.Add(new JsonProperty
                {
                    DeclaringType = type,
                    PropertyType = typeof(Dictionary<string, object>),
                    PropertyName = "things",
                    ValueProvider = new ThingValueProvider(),
                    Readable = true,
                    Writable = false
                });
            }
            return properties;
        }
        private class ThingValueProvider : IValueProvider
        {
            public object GetValue(object target)
            {
                // target should be a Thing; we want to get its Thing properties
                // and group them into a Dictionary.
                return target.GetType().GetProperties()
                             .Where(p => typeof(Thing).IsAssignableFrom(p.PropertyType))
                             .ToDictionary(p => p.Name, p => p.GetValue(target));
            }
            public void SetValue(object target, object value)
            {
                throw new NotImplementedException();
            }
        }
    }
