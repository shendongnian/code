    public class EnumConverter
    {
        public static Dictionary<string, int> EnumToDict<TEnum>() where TEnum : struct, IConvertible
        {
            Type enumType = typeof (TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException("T must be an enum.");
            return Enum.GetValues(typeof (TEnum))
                       .Cast<TEnum>()
                       .ToDictionary(t => t.ToString(), t => t.ToInt32(null /* 'culture' */));
        }
    }
