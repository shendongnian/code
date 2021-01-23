    public static class cHelperClass
    {
        #region GetValuesAndDescriptions
        public static object[] GetValuesAndDescriptions(Type enumType)
        {
            var kvPairList = new List<KeyValuePair<string, string>>();
            var listValue = Enum.GetValues(enumType);
            for (var i = 0; i < listValue.Length; i++)
            {
                var value = listValue.GetValue(i);
                var enumValue = (Enum)listValue.GetValue(i);
                kvPairList.Add(new KeyValuePair<string, string>(value.ToString(), GetDescription(enumValue)));
            }
            var valuesAndDescriptions = from kv in kvPairList select new
            {
                Value = kv.Key,
                Description = kv.Value
            };
            return valuesAndDescriptions.ToArray();
        }
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
        public static string GetStringValue(this Enum enumItem)
        {
            return enumItem
                .GetType()
                .GetField(enumItem.ToString())
                .GetCustomAttributes<StringValueAttribute>()
                .Select(a => a.Value)
                .FirstOrDefault() ?? enumItem.ToString();
        }
        public static string GetName(Type enumType, object value)
        {
            return Enum.GetName(enumType, value);
        }
        #endregion
    }
