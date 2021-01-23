       public static class EnumExtensions
    {
        public static String Humanize(this Enum source)
        {
            return source.Attribute<DescriptionAttribute>().Description;
        }
        public static String Humanize<T>(this IEnumerable<T> source) where T : struct, IConvertible
        {
            return String.Join(", ", source.Cast<T>().Select(x => x.Attribute<DescriptionAttribute>().Description));
        } // Humanize
        public static T Attribute<T>(this IConvertible value) where T : Attribute
        {
            MemberInfo info = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            if (info != null)
                return (T)info.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            return null;
        } // Attribute
    }
