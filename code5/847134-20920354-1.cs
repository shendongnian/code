    var type = GetNumberColumnType(entity);
    FieldInfo fi = type.GetField("MaxValue");
    if(fi!=null && fi.IsLiteral && !fi.IsInitOnly)
    {
        object value = fi.GetRawConstantValue();
    }
