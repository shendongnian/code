    var baseType = GetType().BaseType;
    if (baseType != null)
    {
        var eventMethod = baseType.GetMethod("button_Click", BindingFlags.NonPublic | 
                                                             BindingFlags.Instance);
    }
