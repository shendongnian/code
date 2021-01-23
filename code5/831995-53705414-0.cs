        #region GUID
        public static Guid GGuid(SqlDataReader reader, string field)
        {
            try
            {
                return reader[field] == DBNull.Value ? Guid.Empty : (Guid)reader[field];
            }
            catch { return Guid.Empty; }
        }
        public static Guid GGuid(SqlDataReader reader, int ordinal = 0)
        {
            try
            {
                return reader[ordinal] == DBNull.Value ? Guid.Empty : (Guid)reader[ordinal];
            }
            catch { return Guid.Empty; }
        }
        public static Guid? NGuid(SqlDataReader reader, string field)
        {
            try
            {
                if (reader[field] == DBNull.Value) return (Guid?)null; else return (Guid)reader[field];
            }
            catch { return (Guid?)null; }
        }
        public static Guid? NGuid(SqlDataReader reader, int ordinal = 0)
        {
            try
            {
                if (reader[ordinal] == DBNull.Value) return (Guid?)null; else return (Guid)reader[ordinal];
            }
            catch { return (Guid?)null; }
        }
        #endregion
