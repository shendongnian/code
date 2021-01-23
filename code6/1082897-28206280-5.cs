        public interface IResponseItem // base interface for all possible responses
        {
        }
        public class FamilyResponse : IResponseItem
        {
            public List<FamilyMember> Family { get; set; }
        }
        public class OptionsResponse : IResponseItem
        {
            public int OptionChoice { get; set; }
            public string OptionText { get; set; }
        }
 
    In complex serialization situations like this people seem to prefer Json.NET, nevertheless it's still possible with `JavaScriptSerializer` as per your question.  You must code up a [`JavaScriptConverter`](https://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptconverter%28v=vs.110%29.aspx) to select the appropriate derived type from the base `IResponseItem` type by matching the property names, for instance:
        public class PolymorphicTypeConverter : JavaScriptConverter
        {
            public Type BaseType { get; private set; }
            public Type[] DerivedTypes { get; private set; }
            public PolymorphicTypeConverter(Type baseType, IEnumerable<Type> derivedTypes)
            {
                this.BaseType = baseType;
                this.DerivedTypes = derivedTypes.ToArray();
            }
            static MemberInfo FindMember(Type type, string name)
            {
                try
                {
                    var propInfo = type.GetProperty(name,
                        BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                    if (propInfo != null
                        && propInfo.GetSetMethod() != null
                        && propInfo.GetIndexParameters().Length == 0)
                        return propInfo;
                    var fieldInfo = type.GetField(name,
                        BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                    if (fieldInfo != null)
                        return fieldInfo;
                }
                catch (AmbiguousMatchException)
                {
                    return null;
                }
                return null;
            }
            IEnumerable<Type> AncestorsAndSelf(Type type)
            {
                for (; type != null; type = type.BaseType)
                    if (DerivedTypes.Contains(type))
                        yield return type;
            }
            Type FindUniqueTypeMatch(IDictionary<string, object> jsonProperties)
            {
                List<Type> matches = new List<Type>();
                foreach (var type in DerivedTypes)
                {
                    if (type.IsInterface)
                        continue; // Bug?
                    bool isMatch = true;
                    foreach (var name in jsonProperties.Keys)
                    {
                        if (FindMember(type, name) == null)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch)
                    {
                        matches.Add(type);
                    }
                }
                if (matches.Count == 0)
                    return null;
                else if (matches.Count == 1)
                    return matches[0];
                else
                {
                    // Multiple matches.
                    // If there is a common base type to all matches, return it.  Otherwise, give up.
                    var candidates = AncestorsAndSelf(matches[0]).Reverse();
                    foreach (var match in matches.Skip(1))
                    {
                        candidates = candidates.Zip(AncestorsAndSelf(match).Reverse(), (t1, t2) => (t1 == t2 ? t1 : null)).Where(t => t != null);
                    }
                    return candidates.LastOrDefault();
                }
            }
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                var subtype = FindUniqueTypeMatch(dictionary);
                if (subtype == null)
                    throw new JsonSerializationException();
                var method = serializer.GetType().GetMethod("ConvertToType");
                var generic = method.MakeGenericMethod(subtype);
                return generic.Invoke(serializer, new object [] { dictionary } );
            }
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                // Should never be called.
                throw new NotImplementedException();
            }
            public override IEnumerable<Type> SupportedTypes
            {
                get
                {
                    return new Type[] { BaseType };
                }
            }
        }
    This only works when each object in your JSON array has properties that match one and only one type in the derived type array.  If this cannot be guaranteed, because, for instance, null fields were not serialized leading to multiple matches, you will need to enhance the converter to make a best guess match.
    Then call it like:
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new PolymorphicTypeConverter(typeof(IResponseItem), new Type[] { typeof(FamilyResponse), typeof(OptionsResponse) }) });
            var responseArray = serializer.Deserialize<IResponseItem[]>(json);
 
