	public static bool IsDBNull(object value) {
        if (value == System.DBNull.Value) return true;
        IConvertible convertible = value as IConvertible;
        return convertible != null? convertible.GetTypeCode() == TypeCode.DBNull: false;
    }
