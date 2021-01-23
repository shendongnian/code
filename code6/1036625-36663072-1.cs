    public class DapperHelpers
    {
         public static dynamic ToExpandoObject(object value)
         {
             IDictionary<string, object> dapperRowProperties = value as IDictionary<string, object>;
    
             IDictionary<string, object> expando = new ExpandoObject();
    
             foreach (KeyValuePair<string, object> property in dapperRowProperties)
                 expando.Add(property.Key, property.Value);
    
             return expando as ExpandoObject;
         }
    }
