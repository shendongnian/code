    void Main()
    {
        button1.Dump();
        SetProperties(this,
            "button1.Visible=true",
            "button1.Text=\"Number\""
        );
        button1.Dump();
    }
    
    public static void SetProperties(object instance, params string[] propertySpecifications)
    {
        SetProperties(instance, (IEnumerable<string>)propertySpecifications);
    }
    
    public static void SetProperties(object instance, IEnumerable<string> propertySpecifications)
    {
        var re = new Regex(@"^(?<object>[a-z_][a-z0-9_]*)\.(?<member>[a-z_][a-z0-9_]*)=(?<value>.*)$", RegexOptions.IgnoreCase);
        foreach (var propertySpecification in propertySpecifications)
        {
            var ma = re.Match(propertySpecification);
            if (!ma.Success)
                throw new InvalidOperationException("Invalid property specification: " + propertySpecification);
    
            string objectName = ma.Groups["object"].Value;
            string memberName = ma.Groups["member"].Value;
            string valueString = ma.Groups["value"].Value;
            object value;
            if (valueString.StartsWith("\"") && valueString.EndsWith("\""))
                value = valueString.Substring(1, valueString.Length - 2);
            else
                value = valueString;
    
            var obj = GetObject(instance, objectName);
            if (obj == null)
                throw new InvalidOperationException("No object with the name " + objectName);
    
            var fi = obj.GetType().GetField(memberName);
            if (fi != null)
                fi.SetValue(obj, Convert.ChangeType(value, fi.FieldType));
            else
            {
                var pi = obj.GetType().GetProperty(memberName);
                if (pi != null && pi.GetIndexParameters().Length == 0)
                    pi.SetValue(obj, Convert.ChangeType(value, pi.PropertyType));
                else
                    throw new InvalidOperationException("No member with the name " + memberName + " on the " + objectName + " object");
            }
        }
    }
    
    private static object GetObject(object instance, string memberName)
    {
        var type = instance.GetType();
        var fi = type.GetField(memberName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default);
        if (fi != null)
            return fi.GetValue(instance);
    
        var pi = type.GetProperty(memberName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default);
        if (pi != null && pi.GetIndexParameters().Length == 0)
            return pi.GetValue(instance, null);
    
        return null;
    }
    
    private Button button1 = new Button();
    
    public class Button
    {
        public bool Visible;
        public string Text { get; set; }
    }
