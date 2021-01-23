    public class DynamicInvoke
    {
        List<object> Parameters { get; set; }
        List<string> Paths { get; set; }
        object Instance { get; set; }
        Type Type { get; set; }
        public DynamicInvoke(string path, params object[] parameters)
        {
            Parameters = parameters.ToList();
            Paths = path.Split('+').ToList();
            Type = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(x => x.GetName().Name == Paths[0])
                            .First()
                            .GetTypes()
                            .Where(x => x.FullName == Paths[1])
                            .First();
            Instance = Activator.CreateInstance(Type, Parameters.ToArray());
        }
        public T DynamicPropertyGet<T>()
        { 
            return (T)Type.GetProperty(Paths[2]).GetValue(Instance, null);            
        }
        public void DynamicPropertySet(object value)
        {
            Type.GetProperty(Paths[2]).SetValue(Instance, value, null);
        }
        public T DynamicMethodInvoke<T>(params object[] parameters)
        { 
            return (T)Type.GetMethods()
                          .Where(x => x.Name == Paths[2] && AreAllEqual(x, parameters))                          
                          .First()
                          .Invoke(Instance, parameters);
        }
        bool AreAllEqual(MethodInfo method, params object[] parameters)
        {
            var p1 = method.GetParameters().Select(x => x.ParameterType);
            var p2 = parameters.Select(x => x.GetType());
            var except1 = p1.Except(p2).ToList().Count;
            var except2 = p2.Except(p1).ToList().Count;
            return (except1 > 0 || except2 > 0) ? false : true;
        }
    }
