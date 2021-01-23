    public static class EnumHelpers
    {
        public static EnumValue GetEnumValue(object value, Type enumType)
        {
            MemberInfo member = enumType.GetMember(value.ToString())[0];
            
            DisplayAttribute attribute = 
                member.GetCustomAttribute<DisplayAttribute>();
                
            return new EnumValue
            {
                Value = (int)value,
                Name = Enum.GetName(enumType, value),
                Label = attribute.Name
            };
        }
    
        public static EnumValue[] GetEnumValues(Type enumType)
        {
            Array values = Enum.GetValues(enumType);
            
            EnumValue[] result = new EnumValue[values.Length];
            
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = GetEnumValue(
                    values.GetValue(i),
                    enumType);
            }
            
            return result;
        }
    }
