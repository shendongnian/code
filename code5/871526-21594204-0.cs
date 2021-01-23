    public class MyMethod(object obj)
    {
        Type t = obj.GetType();
        PropertyInfo prop = t.GetProperty("Items");
        var x = prop.GetValue(obj, null);
    }
