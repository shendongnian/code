    static void SetPropertyValue(object p, string propName, object value)
        {
            Type t = p.GetType();
    
            System.Reflection.PropertyInfo info = t.GetProperty(propName);
            
            if (info == null)
                return;
            if (!info.CanWrite)
                return;
    
            var elemtype = info.PropertyType.GetElementType();
            var castmethod = typeof(Enumerable).GetMethod("Cast",BindingFlags.Public| BindingFlags.Static).MakeGenericMethod(elemtype);
    
            info.SetValue(p, castmethod.Invoke(null, new object[] { value }), null);
        }
