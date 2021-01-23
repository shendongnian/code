    public class ClassIndexer
    {
        Random pNext = new Random();
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
        public object ParamForObject(object obj, ParameterInfo pi)
        {
            if (obj is IDictionary)
            {
                int maxNumber = ((IDictionary)obj).Keys.Count;
                if (pi.ParameterType.Equals(typeof(int)))
                {
                    return pNext.Next(maxNumber);
                }
                if (pi.ParameterType.Equals(typeof(string)))
                {
                    int target = pNext.Next(maxNumber);
                    foreach (var key in ((IDictionary)obj).Keys)
                    {
                        target--;
                        if (target <= 0)
                        {
                            return key;
                        }
                    }
                    return null;
                }
            }
            if (obj is string)
            {
                if (pi.ParameterType.Equals(typeof(int)))
                {
                    return pNext.Next((obj as string).Length);
                }
            }
            if (obj is IList)
            {
                return pNext.Next(((IList)obj).Count);
            }
            if (pi.ParameterType.Equals(typeof(string)))
            {
                return "Key";
            }
            if (pi.ParameterType.Equals(typeof(int)))
            {
                return pNext.Next(100);
            }
            return null;
        }
        public ClassIndexer()
        {
        }
    }
