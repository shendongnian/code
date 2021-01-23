    public static class EnumExtensions
    { 
        public static int AsInt<TEnum>(this TEnum enumType) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an enum type");
            return ((IConvertible)enumType).ToInt32(null);
        }
    }
    var url = "~/Somethimg?var=" + myEnum.AsInt();
