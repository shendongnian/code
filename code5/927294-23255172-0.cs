    static class Program
    {
        static void Main()
        {
            var names =
                GetMethodsWithParameter(typeof(object), "startIndex")
                .Concat(GetMethodsWithParameter(typeof(Uri), "startIndex"))
            .Distinct();
            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }
    
        private static IEnumerable<string> GetMethodsWithParameter(Type assemblyOrigin, string name)
        {
            foreach(var type in assemblyOrigin.Assembly.GetTypes())
            {
                foreach(var method in type.GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    if(method.GetParameters().Any(x => x.Name == name))
                    {
                        yield return type.FullName + "." + method.Name;
                    }
                }
            }
        }
    }
