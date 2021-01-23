    public sealed class TrimAttribute : Attribute {
    }
    public static class TrimConverterExtension {
      public static void SetValue(this MemberInfo member, object property, object value) {
         switch (member.MemberType) {
            case MemberTypes.Property:
               ((PropertyInfo)member).SetValue(property, value, null);
               break;
            case MemberTypes.Field:
               ((FieldInfo)member).SetValue(property, value);
               break;
            default:
               throw new Exception("Property must be of type FieldInfo or PropertyInfo");
         }
      }
      public static object GetValue(this MemberInfo member, object property) {
         switch (member.MemberType) {
            case MemberTypes.Property:
               return ((PropertyInfo)member).GetValue(property, null);
            case MemberTypes.Field:
               return ((FieldInfo)member).GetValue(property);
            default:
               throw new Exception("Property must be of type FieldInfo or PropertyInfo");
         }
      }
      public static Type GetMemberType(this MemberInfo member) {
         switch (member.MemberType) {
            case MemberTypes.Field:
               return ((FieldInfo)member).FieldType;
            case MemberTypes.Property:
               return ((PropertyInfo)member).PropertyType;
            case MemberTypes.Event:
               return ((EventInfo)member).EventHandlerType;
            default:
               throw new ArgumentException("MemberInfo must be if type FieldInfo, PropertyInfo or EventInfo", "member");
         }
      }
    }
    public class TrimConverter<T> : JsonConverter where T : new() {
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
         var jObject = JObject.Load(reader);
         var obj = new T();
         serializer.Populate(jObject.CreateReader(), obj);
         //Looks for the trim attribute on the property
         const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
         IEnumerable<MemberInfo> members = objectType.GetFields(bindingFlags).Cast<MemberInfo>()
             .Concat(objectType.GetProperties(bindingFlags))
             .Where(p => p.GetMemberType() == typeof(string))
             .Where(p => Attribute.GetCustomAttributes(p).Any(u => (Type)u.TypeId == typeof(TrimAttribute)))
             .ToArray();
         foreach (var fieldInfo in members) {
            var val = (string)fieldInfo.GetValue(obj);
            if (!string.IsNullOrEmpty(val)) {
               fieldInfo.SetValue(obj, val.Trim());
            }
         }
         return obj;
      }
      public override bool CanConvert(Type objectType) {
         return objectType.IsAssignableFrom(typeof(T));
      }
    }
 
