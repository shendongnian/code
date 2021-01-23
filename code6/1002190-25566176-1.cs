    private static T InvokeFunction<T>(Func<T> func)
        {
           Dictionary<string, Func<MyObject, T>> sortMappings =
           new Dictionary<string, Func<MyObject, T>>();
           sortMappings.Add("Name", b => (T)System.Convert.ChangeType(b.Name,typeof(T)));
           sortMappings.Add("Length", b => (T)System.Convert.ChangeType(b.Length, typeof(T)));
           sortMappings.Add("Date", b => (T)System.Convert.ChangeType(b.Date, typeof(T)));
           return func.Invoke();
        }
