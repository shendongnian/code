      public static string GetDescription(System.Enum value)
        {
            FieldInfo FieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])FieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
       if ((attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }
    
        public static List<KeyValuePair<string, string>> GetValuesAndDescription(System.Type enumType)
        {
            List<KeyValuePair<string, string>> kvPairList = new List<KeyValuePair<string, string>>();
            foreach (System.Enum enumValue in System.Enum.GetValues(enumType))
            {
                kvPairList.Add(new KeyValuePair<string, string>(enumValue.ToString(), GetDescription(enumValue)));
            }
            return kvPairList;
        }
