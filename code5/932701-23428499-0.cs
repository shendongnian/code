    static class Test
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, Action<object>>();
            AddAction<double>(dictionary, "somestring", SampleMethod);
        }
        
        static void AddAction<T>(Dictionary<string, Action<object>> dictionary,
                                 string name,
                                 Action<T> action)
        {
            dictionary.Add(name, arg => action((T) arg));
        }
    
        static void SampleMethod(double input)
        {
        }
    }
