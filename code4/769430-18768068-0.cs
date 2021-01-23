    public interface ISerializableEntity { };
    
    public class CustomerEntity : ISerializableEntity
    {
        ....
    }
    
    public static class Extensions
    {
        public static IDictionary<string, object> ToSerializable(
            this ISerializableEntity obj)
        {
            var result = new Dictionary<string, object>();
    
            foreach (var property in obj.GetType().GetProperties().ToList())
            {
                var value = property.GetValue(obj, null);
    
                if (value != null && (value.GetType().IsPrimitive 
                      || value is decimal || value is string || value is DateTime 
                      || value is List<object>))
                {
                    result.Add(property.Name, value);
                }
            }
    
            return result;
        }
    }
