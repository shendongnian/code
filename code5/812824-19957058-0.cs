    public static class Extensions
    {
        public static void SetValue(this KeyValueConfigurationCollection o,
            string key,
            string val)
        {
            if (!o.AllKeys.Contains(key)) { o.Add(key, val); }
            else { o[key].Value = val; }
        }
        public static string GetValue(this NameValueCollection o,
            string key,
            object defaultVal = null)
        {
            if (!o.AllKeys.Contains(key)) { return Convert.ToString(defaultVal); }
            return o[key];
        }
    }
