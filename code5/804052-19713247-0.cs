        internal Dictionary<string, object> GetDict(DataTable dt)
        {
            Dictionary<String, Object> dic = dt.AsEnumerable().ToDictionary(row => row.Field<String>(0), row => row.Field<Object>(1));
            return dic;
        }
