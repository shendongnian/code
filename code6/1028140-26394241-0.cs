    public static class MyEnumerable
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> input, Dictionary<string, object> parameters)
        {
            var constructor_parameters = typeof(T).GetConstructors()[0].GetParameters().Select(p => p.Name).ToArray();
                
            if (parameters.Count != constructor_parameters.Length) throw new ArgumentException("Passed parameters count differs from real property count.");
            if (constructor_parameters.Any(p => !parameters.ContainsKey(p))) throw new ArgumentException("Some of properties are not present in a dictionary.");
    
            var newobject = new T[] { (T)Activator.CreateInstance(typeof(T), constructor_parameters.Select(name=>parameters[name]).ToArray()) };
            return input.Concat(newobject);
        }
    }
