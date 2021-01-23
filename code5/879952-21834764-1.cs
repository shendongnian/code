    public class Request
    {
        public string method;
        public object[] parameters;
    }
    public static T Exec<T>(string json, object target) 
    {
        var req = JsonConvert.DeserializeObject<Request>(json);
        var method = target.GetType().GetMethod(req.method, BindingFlags.Public | BindingFlags.Instance);
        if (method == null) throw new InvalidOperationException();
        object[] parameters = new object[0];
        if (req.parameters != null)
        {
            parameters = method.GetParameters().Zip(req.parameters, (m, p) => Convert.ChangeType(p, m.ParameterType)).ToArray();
        }
            
        return (T)method.Invoke(target, parameters);
    }
