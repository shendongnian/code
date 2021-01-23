    public static class EnumExtensions
    {
        public static bool HasFlags<TEnum>(this TEnum @enum,
                                           TEnum flag,
                                           params TEnum[] flags)
            where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum)
                throw new ArgumentException("@enum is not an Enum");
            var hasFlagsMethod = type.GetMethod("HasFlag");
            var hasFlag = new Func<TEnum, bool>(e =>
            {
                return (bool)hasFlagsMethod.Invoke(@enum, new object[] { e });
            });
            // test the first flag argument
            if (!hasFlag(flag))
                return false;
            // test the params flags argument
            foreach (var flagValue in flags)
            {
                if (!hasFlag(flagValue))
                    return false;
            }
            return true;
        }
    }
