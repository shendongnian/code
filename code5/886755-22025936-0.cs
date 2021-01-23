    public static class Extension{
        public static T Isnull<T>(this Object value){
            if(value == null || value == DBNull.Value)
                return default(T);
            (T)Convert.ChangeType(value, typeof(T)));
        }
    }
