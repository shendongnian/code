    public static string GetString(this SqlDataReader reader, string name) {
        return GetFieldValue<String>(reader, name, (string)null);
    }
    public static T GetFieldValue<T>(this SqlDataReader reader, string fieldName, T defaultvalue = default(T)) {
        try {
            var value = reader[fieldName];
            if (value == DBNull.Value || value == null)
                return defaultvalue;
            return (T)value;
        } catch (Exception e) {
            //SimpleLog.Error("Error reading databasefield " + fieldName + "| ", e);
        }
        return defaultvalue;
    }
