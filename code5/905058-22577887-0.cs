    // helper for Adding parameters to a list
    public static class SqlParameters
    {  
        // or have strongly typed overloads
        public static List<SqlParameter> Add(
            this List<SqlParameter> list, 
            string paramName, 
            object value)
        {  
            var p =new SqlParameter(
                        paramName, 
                        Map(value.GetType()));
            p.Value = value;
            list.Add(p);
            return list;
        }
        
        private static DbType Map(Type type)
        {
            DbType dbtype = DbType.Object;
            if (type == typeof(System.String))
            {
                dbtype = DbType.String;
            }
            if (type == typeof(System.Int32))
            {
                dbtype = DbType.Int32;
            }
            return dbtype;
        }
    }
