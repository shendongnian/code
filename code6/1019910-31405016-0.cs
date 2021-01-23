    public class TypeHintContractResolver : DefaultContractResolver
    {
      
      protected override IList<JsonProperty> CreateProperties(Type type,
          MemberSerialization memberSerialization)
      {
        IList<JsonProperty> result = base.CreateProperties(type, memberSerialization);
        if (type == typeof(A))
        {
          result.Add(CreateTypeHintProperty(type,"Hint", "A"));
        }
        else if (type == typeof(B))
        {
          result.Add(CreateTypeHintProperty(type,"Target", "B"));
        }
        else if (type == typeof(C))
        {
          result.Add(CreateTypeHintProperty(type,"Is", "C"));
        }
        return result;
      }
      
      private JsonProperty CreateTypeHintProperty(Type declaringType, string propertyName, string propertyValue)
      {
        return new JsonProperty
        {
            PropertyType = typeof (string),
            DeclaringType = declaringType,
            PropertyName = propertyName,
            ValueProvider = new TypeHintValueProvider(propertyValue),
            Readable = false,
            Writable = true
        };
      }
    }
