    public static object GetValue(string value) {
      if (!String.IsNullOrEmpty(value)) {
        return value;
      }
      return DBNull.Value;
    }
