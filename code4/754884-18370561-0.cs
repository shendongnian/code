    public void SetFieldValue(FieldInfo field, object targetObj, object value)
    {
        object valueToSet;
    
        if (value == null  || value == DBNull.Value)
        {
          valueToSet = null;
        }
        else
        {
          Type fieldType = field.FieldType;
          //assign enum
          if (fieldType.IsEnum)
              valueToSet = Enum.ToObject(fieldType, value);
          //support for nullable enum types
          else if (fieldType.IsValueType && IsNullableType(fieldType))
          {
              Type underlyingType = Nullable.GetUnderlyingType(fieldType);
              valueToSet = underlyingType.IsEnum ? Enum.ToObject(underlyingType, value) : value;
          }
          else
          {
              //we always need ChangeType, it will convert the value to the proper number type, for example.
              valueToSet = Convert.ChangeType(value, fieldType);
          }
        }
        field.SetValue(targetObj, valueToSet);
    }
