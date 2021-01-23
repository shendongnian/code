    namespace ExtentionMethodPractises
    {
        static public class ExtensionMethods
        {
            public static T ParseOrDefault<T>(this T targetType, string source)
                where T : new()
            {
                if (targetType.GetType()
                    .GetMethods(BindingFlags.Static|BindingFlags.Public)
                    .Any(methodInfo => methodInfo.Name == "TryParse"))
                {
                    var result = new T();
    
                    var parameterTypes = new Type[] {source.GetType(),
                            
                              //Key change here
                              targetType.GetType().MakeByRefType()};
    
                    var tryParseMethod = targetType.GetType()
                        .GetMethod("TryParse", parameterTypes);
    
                    tryParseMethod.Invoke(null, new object[] {source, result});
    
                    return result;
                }
    
                return new T();
            }
        }
    }
