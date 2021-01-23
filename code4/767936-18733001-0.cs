    using System.Reflection;
    
    public SolidColorBrush ColorStringToBrush(string name)
    {
        var property = typeof(Colors).GetRuntimeProperty(name);
        if (property != null)
        {
            return new SolidColorBrush((Color)property.GetValue(null));
        }
        else
        {
            return null;
        }
    }
