        public class Converter
        {
            public static Int16 ToInt16(object value)
            {
                return ChangeType<Int16>(value);
            }
            public static Int32 ToInt32(object value)
            {
                return ChangeType<Int32>(value);
            }
            public static Int64 ToInt64(object value)
            {
                return ChangeType<Int64>(value);
            }
            public static Single ToSingle(object value)
            {
                return ChangeType<Single>(value);
            }
            public static Boolean ToBoolean(object value)
            {
                return ChangeType<Boolean>(value);
            }
            public static System.String ToString(object value)
            {
                return ChangeType<System.String>(value);
            }
            public static DateTime ToDateTime(object value)
            {
                return ChangeType<DateTime>(value);
            }
            public static Decimal ToDecimal(object value)
            {
                return ChangeType<Decimal>(value);
            }
            public static Double ToDouble(object value)
            {
                return ChangeType<Double>(value);
            }
            public static Guid ToGuid(object value)
            {
                return ChangeType<Guid>(value);
            }
            public static Byte ToByte(object value)
            {
                return ChangeType<Byte>(value);
            }
            public static Byte[] ToBytes(object value)
            {
                return ChangeType<Byte[]>(value);
            }
            public static DateTime? ToDateTimeNull(object value)
            {
                return ChangeType<DateTime?>(value);
            }
            public static System.Int32? ToInt32Null(object value)
            {
                return ChangeType<Int32?>(value);
            }
            public static Boolean? ToBooleanNull(object value)
            {
                return ChangeType<Boolean?>(value);
            }
            private static T ChangeType<T>(object value)
            {
                var t = typeof(T);
                if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    if (value == null)
                    {
                        return default(T);
                    }
                    t = Nullable.GetUnderlyingType(t); ;
                }
                return (T)Convert.ChangeType(value, t);
            }
        }
