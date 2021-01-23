    public enum MyDayOfWeek
    {
        [UserFriendlyName("Sunday")]
        Sunday = 0,
        [UserFriendlyName("Monday")]
        Monday = 1,
        [UserFriendlyName("Tuesday")]
        Tuesday = 2,
        [UserFriendlyName("Wednesday")]
        Wednesday = 3,
        [UserFriendlyName("Thursday")]
        Thursday = 4,
        [UserFriendlyName("Friday")]
        Friday = 5,
        [UserFriendlyName("Saturday")]
        Saturday = 6,
        [UserFriendlyName("Sunday until Friday")]
        SunTilFir = 7
    }
    public class UserFriendlyNameAttribute : Attribute
    {
        public string Text { get; set; }
        public UserFriendlyNameAttribute(string text)
        {
            Text = text;
        }
    }
    public static class EnumExtensions
    {
        public static string GetUserFriendlyName(this MyDayOfWeek myDayOfWeek)
        {
            return GetUserFriendlyNameAttributeText(typeof(MyDayOfWeek), myDayOfWeek.ToString());
        }
        private static string GetUserFriendlyNameAttributeText(this Type type, string memberName)
        {
            var memInfo = type.GetMember(memberName);
            if (memInfo.Length == 0)
                return string.Empty;
            var attributes = memInfo[0].GetCustomAttributes(typeof(UserFriendlyNameAttribute), false);
            if (attributes.Length == 0)
                return null;
            return ((UserFriendlyNameAttribute) attributes[0]).Text;
        }
    }
