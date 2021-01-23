    class ValueRange<T>
    {
        public static string GetRange()
        {
            FieldInfo maxValueField = typeof(T).GetField("MaxValue", BindingFlags.Public | BindingFlags.Static);
            FieldInfo minValueField = typeof(T).GetField("MinValue", BindingFlags.Public | BindingFlags.Static);
            return string.Format("{0} to {1}", minValueField.GetValue(null), maxValueField.GetValue(null));
        }
    }
