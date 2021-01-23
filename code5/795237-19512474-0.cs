    public class CFactory
    {
        public C Create(string name, string value)
        {
            C result = new C();
            var props = result.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public
                                                    | BindingFlags.Instance | BindingFlags.Static);
            var nameProp = props.FirstOrDefault(p => p.Name == "name");
            var valProp = props.FirstOrDefault(p => p.Name == "value");
            if (nameProp != null) nameProp.SetValue(result, name);
            if (valProp != null) valProp.SetValue(result, value);
            return result;
        }
    }
