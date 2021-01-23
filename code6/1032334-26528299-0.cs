        public static T? ParseEnum<T>(this ViewDataDictionary d, string key)
            where T : struct
        {
            var dictObject = d[key];
            if (null == dictObject)
                return null;
            if (dictObject is T?)
                return dictObject as T?;
            T parsedEnum;
            if (Enum.TryParse(dictObject.ToString(), out parsedEnum))
                return parsedEnum;
            return null;
        }
