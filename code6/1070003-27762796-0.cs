    internal static class MyStringExtensions {
    
       public static string GetValueOrDefault(this string extendee, string defaultValue) {
    
         if(string.IsNullOrEmpty(extendee)) { return defaultValue;}
         return extendee;
       }
    }
