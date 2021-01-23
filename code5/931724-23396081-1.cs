    public static T Get<T>(this SqlDataReader reader, string field) 
    {
        try {
            int index = reader.GetOrdinal(field);
            if (reader.IsDBNull(index)) return default(T);
            object item = reader[index];
            return item is T ? (T)item : (T)Convert.ChangeType(item, typeof(T));
        } catch (Exception e) {
            Console.WriteLine(e); 
            return default(T); 
        }
    }
