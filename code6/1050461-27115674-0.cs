    foreach (var prop in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(prop => Attribute.IsDefined(prop, typeof(CalcProgressAttribute))))
    {
    
     object value = prop.GetValue(this, null);
    
    }
