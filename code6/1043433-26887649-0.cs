        public static string GetDescription(Enum value)
        {
            string ret = value.ToString();
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                var att = fi.GetCustomAttribute<DescriptionAttribute>(true);
                if (att != null)
                    ret = att.Description;
            }
            return ret;
        }
