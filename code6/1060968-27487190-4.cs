    public IList<MethodInfo> GetIndexProperties(object obj)
    {
        if (obj == null)
        {
            return null;
        }
        var type = obj.GetType();
        IList<MethodInfo> results = new List<MethodInfo>();
        try
        {
            var props = type.GetProperties(System.Reflection.BindingFlags.Default | 
                System.Reflection.BindingFlags.Public | 
                System.Reflection.BindingFlags.Instance);
            if (props != null)
            {
                foreach (var prop in props)
                {
                    var indexParameters = prop.GetIndexParameters();
                    if (indexParameters == null || indexParameters.Length == 0)
                    {
                        continue;
                    }
                    var getMethod = prop.GetGetMethod();
                    if (getMethod == null)
                    {
                        continue;
                    }
                    results.Add(getMethod);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return results;
    }
