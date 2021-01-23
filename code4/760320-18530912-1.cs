    public static T? DbCast<T>(this object dbValue)
            where T : struct
        {
            if (dbValue == null)
            {
                return null;
            }
            if (dbValue is System.DBNull)
            {
                return null;
            }
            T? value = dbValue as T?;
            if (value != null)
            {
                return value;
            }
            var conv = dbValue as IConvertible;
            if (conv != null)
            {
                value = (T)conv.ToType(typeof(T), CultureInfo.InvariantCulture);
            }
            return value;
        }
