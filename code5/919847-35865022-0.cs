    public class CustomContractResolver : DefaultContractResolver {
        
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var c = base.CreateObjectContract(objectType);
            if (!IsCustomStruct(objectType)) return c;
        
            IList<ConstructorInfo> list = objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OrderBy(e => e.GetParameters().Length).ToList();
            var mostSpecific = list.LastOrDefault();
            if (mostSpecific != null)
            {
                c.OverrideCreator = CreateParameterizedConstructor(mostSpecific);
                c.CreatorParameters.AddRange(CreateConstructorParameters(mostSpecific, c.Properties));
            }
        
            return c;
        }
        
        protected virtual bool IsCustomStruct(Type objectType)
        {
            return objectType.IsValueType && !objectType.IsPrimitive && !objectType.IsEnum && !objectType.Namespace.IsNullOrEmpty() && !objectType.Namespace.StartsWith("System.");
        }
        
        private ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
        {
            method.ThrowIfNull("method");
            var c = method as ConstructorInfo;
            if (c != null)
                return a => c.Invoke(a);
            return a => method.Invoke(null, a);
        }
    }
