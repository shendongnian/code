    public static class ValidationUtils
    {
        public static void SanitizeStrings<T>(this T dto)
        {
            var pis = dto.GetType().GetProperties();    
            foreach (var pi in pis)
            {
                if (pi.PropertyType != typeof(string)) continue;
                var mi = pi.GetGetMethod();
                var strValue = (string)mi.Invoke(dto, new object[0]);
                if (strValue == null) continue;
                var trimValue = strValue.Trim();
                if (strValue.Length > 0 && strValue == trimValue) continue;
                strValue = trimValue.Length == 0 ? null : trimValue;
                pi.GetSetMethod().Invoke(dto, new object[] { strValue });
            }
        }
    }
