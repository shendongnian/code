    public static class EnumHelper
    {
        // Generic singleton remembering basic properties about specified enums, cached for performance.
        sealed class DataSingleton<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            static readonly DataSingleton<TEnum> instance = new DataSingleton<TEnum>();
            readonly bool isSigned;
            readonly TEnum allValues;
            readonly bool hasFlags;
            readonly bool isEnum;
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static DataSingleton()
            {
            }
            DataSingleton()
            {
                var type = typeof(TEnum);
                isEnum = type.IsEnum;
                if (isEnum)
                {
                    isSigned = GetIsSigned();
                    allValues = GetAll();
                    hasFlags = GetHasFlags();
                }
                else
                {
                    isSigned = false;
                    allValues = default(TEnum);
                    hasFlags = false;
                }
            }
            static bool GetHasFlags()
            {
                var attributes = typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false);
                return attributes != null && attributes.Length > 0;
            }
            static bool GetIsSigned()
            {
                var underlyingType = Enum.GetUnderlyingType(typeof(TEnum));
                bool isSigned = (underlyingType == typeof(long) || underlyingType == typeof(int) || underlyingType == typeof(short) || underlyingType == typeof(sbyte));
                bool isUnsigned = (underlyingType == typeof(ulong) || underlyingType == typeof(uint) || underlyingType == typeof(ushort) || underlyingType == typeof(byte));
                if (!isSigned && !isUnsigned)
                    throw new InvalidOperationException();
                return isSigned;
            }
            static TEnum GetAll()
            {
                if (GetIsSigned())
                {
                    long value = 0;
                    foreach (var v in Enum.GetValues(typeof(TEnum)))
                        // Not sure I need the culture but Microsoft passes it in Enum.ToUInt64(Object value) - http://referencesource.microsoft.com/#mscorlib/system/enum.cs
                        value |= Convert.ToInt64(v, CultureInfo.InvariantCulture);
                    return (TEnum)Enum.ToObject(typeof(TEnum), value);
                }
                else
                {
                    ulong value = 0;
                    foreach (var v in Enum.GetValues(typeof(TEnum)))
                        // Not sure I need the culture but Microsoft passes it in Enum.ToUInt64(Object value) - http://referencesource.microsoft.com/#mscorlib/system/enum.cs
                        value |= Convert.ToUInt64(v, CultureInfo.InvariantCulture);
                    return (TEnum)Enum.ToObject(typeof(TEnum), value);
                }
            }
            public bool HasFlags { get { return hasFlags; } }
            public bool IsSigned { get { return isSigned; } }
            public TEnum AllValues { get { return allValues; } }
            public bool IsEnum { get { return isEnum; } }
            public static DataSingleton<TEnum> Instance { get { return instance; } }
        }
        private static void ThrowOnNonEnum<TEnum>(DataSingleton<TEnum> data) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!data.IsEnum)
            {
                throw (new ArgumentException("The generic argument [<TEnum>] must be an enumeration.", "TEnum: " + typeof(TEnum).FullName));
            }
        }
        private static void ThrowOnEnumWithFlags<TEnum>(DataSingleton<TEnum> data) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!data.IsEnum || data.HasFlags)
            {
                throw (new ArgumentException("The generic argument [<TEnum>] must be an enumeration without the [FlagsAttribute] applied.", "TEnum: " + typeof(TEnum).FullName));
            }
        }
        private static void ThrowOnEnumWithoutFlags<TEnum>(DataSingleton<TEnum> data) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!data.IsEnum || !data.HasFlags)
            {
                throw (new ArgumentException("The generic argument [<TEnum>] must be an enumeration with the [FlagsAttribute] applied.", "TEnum: " + typeof(TEnum).FullName));
            }
        }
        public static TEnum GetAll<TEnum>() where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var data = DataSingleton<TEnum>.Instance;
            ThrowOnEnumWithoutFlags<TEnum>(data);
            return data.AllValues;
        }
        static ulong ToUInt64<TEnum>(TEnum value) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            // Silently convert the value to UInt64 from the other base 
            // types for enum without throwing an exception.
            // This is need since the Convert functions do overflow checks.
            TypeCode typeCode = value.GetTypeCode();
            ulong result;
            switch (typeCode)
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    unchecked
                    {
                        result = (UInt64)value.ToInt64(CultureInfo.InvariantCulture);
                    }
                    break;
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Boolean:
                case TypeCode.Char:
                    unchecked
                    {
                        result = value.ToUInt64(CultureInfo.InvariantCulture);
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return result;
        }
        public static string ToDebugString<TEnum>(this TEnum anEnum) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var data = DataSingleton<TEnum>.Instance;
            if (!data.IsEnum || !data.HasFlags)
                return anEnum.ToString();
            var allLong = ToUInt64(data.AllValues);
            var enumLong = ToUInt64(anEnum);
            string str1 = ((TEnum)Enum.ToObject(typeof(TEnum), enumLong & allLong)).ToString(CultureInfo.InvariantCulture);
            var compliment = enumLong & ~(allLong);
            if (compliment == 0)
                return str1;
            return str1 + ", 0x" + ((TEnum)Enum.ToObject(typeof(TEnum), compliment)).ToString("X", CultureInfo.InvariantCulture);
        }
    }
