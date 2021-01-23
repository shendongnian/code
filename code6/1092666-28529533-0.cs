    // This class has to be static for extension methods to be detected
    public static class MyExtensions
    {
        // using "this" before the first parameter will make it an extension of the type
        public static IEnumerable<string> Prop<T>(this IEnumerable<T> enumerable, string propName)
        {
            var type = typeof(T);
            // Note that this can throw an exception if the property is not found
            var info = type.GetProperty(propName);
            // Here are your students, considering that <T> is <Student>
            foreach (var item in enumerable) 
            {
                // return the value fromt the item, I'm using ToString here for
                // simplicity, but since you don't know the property type in
                // advance, you can't really do anything else than assumne its
                // type is plain "object"
                yield return info.GetValue(item).ToString();
            }
        }
    }
