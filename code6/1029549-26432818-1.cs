     public  static class   ExtensionDBNull
         {
     public static float DBNullToFloat(this object TheObject, object DefaultValue)
        {
            return DBNull.Value.Equals(TheObject) ? 0 : Convert.ToSingle(TheObject);
            //if (TheObject is DBNull)
            //    return DefaultValue;
            //return Convert.ToSingle(TheObject);
        }
       }
