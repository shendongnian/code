    internal static class Program
    {
        private static void Main(string[] args)
        {
            ChangeFlag changeFlag = ChangeFlag.REVISED;
            Console.WriteLine(changeFlag.GetDescription());
            Console.Read();
        }
        public enum ChangeFlag
        {
            [Description("New")]
            NEW,
            [Description("Deleted")]
            DELETED,
            [Description("Revised")]
            REVISED
        }
    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            }
            return value.ToString();
        }
    }
