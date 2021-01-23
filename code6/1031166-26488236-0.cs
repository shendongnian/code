    var b1Properties = b1.GetType().GetProperties();
    foreach (var b1Property in b1Properties)
    {
         var b2Property = b2.GetType().GetProperty(pi.Name);
         b2Property.SetValue(b2, b1Property.GetValue(b1));
    }
