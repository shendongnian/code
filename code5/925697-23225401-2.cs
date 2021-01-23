     public static class SqlGenerator
    {
        public static SqlCommand GenerateSelectCommand<T>()
        {
            string TableName = GetTableName<T>();
            PropertyInfo[] props = GetPropertyInfos<T>();
            //StringBuilder sbWhere = new StringBuilder(" WHERE ");
            StringBuilder sbColumns = new StringBuilder(" ");
            var cmd = new SqlCommand();
            foreach (var prop in props)
            {
                sbColumns.Append(prop.Name);
            }
            cmd.CommandText =
                "SELECT " +
                sbColumns.ToString().TrimEnd(',') +
                " FROM " + TableName;
            return cmd;
        }
        public static SqlCommand GenerateInsertCommand<T>(object Obj)
        {
            string TableName = GetTableName<T>();
            PropertyInfo[] props = GetPropertyInfos<T>();
            var cmd = new SqlCommand();
            StringBuilder sbColumns = new StringBuilder(" ");
            StringBuilder sbValues = new StringBuilder(" ");
            foreach(var prop in props)
            {
                var sqlColumnAttr = (SqlColumn)prop.GetCustomAttribute(typeof(SqlColumn), false);
                var colValue = prop.GetValue(Obj);
                if(!sqlColumnAttr.PrimaryKey && colValue!=null)
                {
                    sbColumns.AppendFormat("{0},",sqlColumnAttr.ColumnName);
                    sbValues.AppendFormat("@{0},", sqlColumnAttr.ColumnName);
                    var param = new SqlParameter("@" + sqlColumnAttr.ColumnName, colValue);
                    param.DbType = (DbType)Enum.Parse(typeof(DbType), sqlColumnAttr.ValueType.Name);
                    cmd.Parameters.Add(param);
                }
                
            }
            cmd.CommandText = "INSERT INTO " + TableName +"("+ sbColumns.ToString().TrimEnd(',') +") VALUES(" + sbValues.ToString().TrimEnd(',') + ");SELECT SCOPE_IDENTITY();";
            return cmd;
        }
        public static SqlCommand GenerateUpdateCommand<T>(object Obj,IEnumerable<string> PropertyNamesThatChanged)
        {
            string TableName = GetTableName<T>();
            PropertyInfo[] props = GetPropertyInfos<T>().Where(pinfo=>!PropertyNamesThatChanged.Contains(pinfo.Name)).ToArray();
            var cmd = new SqlCommand();
            StringBuilder sbValues = new StringBuilder(" ");
            StringBuilder sbWhere = new StringBuilder(" WHERE ");
            foreach (var prop in props)
            {
                var sqlColumnAttr = (SqlColumn)prop.GetCustomAttribute(typeof(SqlColumn), false);
                var colValue = prop.GetValue(Obj);
                if (!sqlColumnAttr.PrimaryKey && colValue != null)
                {
                    sbValues.AppendFormat("{0}=@{0},", sqlColumnAttr.ColumnName);
                    var param = new SqlParameter("@" + sqlColumnAttr.ColumnName, colValue);
                    param.DbType = (DbType)Enum.Parse(typeof(DbType), sqlColumnAttr.ValueType.Name);
                    cmd.Parameters.Add(param);
                }
                else if(sqlColumnAttr.PrimaryKey)
                {
                    sbWhere.AppendFormat("{0}=@{0}", sqlColumnAttr.ColumnName);
                    var param = new SqlParameter("@" + sqlColumnAttr.ColumnName, colValue);
                    param.DbType = (DbType)Enum.Parse(typeof(DbType), sqlColumnAttr.ValueType.Name);
                    cmd.Parameters.Add(param);
                }
            }
            cmd.CommandText = "UPDATE " + TableName +  sbValues.ToString().TrimEnd(',') + sbWhere.ToString();
            return cmd;
        }
        public static SqlCommand GenerateDeleteCommand<T>(object Obj)
        {
            string TableName = GetTableName<T>();
            PropertyInfo[] props = GetPropertyInfos<T>();
            StringBuilder sbWhere = new StringBuilder(" WHERE ");
            var cmd = new SqlCommand();
            foreach (var prop in props)
            {
                var sqlColumnAttr = (SqlColumn)prop.GetCustomAttribute(typeof(SqlColumn), false);
                if(sqlColumnAttr.PrimaryKey)
                {
                    var colValue = prop.GetValue(Obj);
                    sbWhere.AppendFormat("{0}=@{0}", sqlColumnAttr.ColumnName);
                    var param = new SqlParameter("@" + sqlColumnAttr.ColumnName, colValue);
                    param.DbType = (DbType)Enum.Parse(typeof(DbType), sqlColumnAttr.ValueType.Name);
                    cmd.Parameters.Add(param);
                }
                
            }
            cmd.CommandText = "DELETE FROM " + TableName + sbWhere.ToString();
            return cmd;
        }
        public static string GetTableName<T>()
        {
            return typeof(T).GetAttributeValue((SqlTable sqlTable)=> sqlTable.TableName);
        }
        public static PropertyInfo[] GetPropertyInfos<T>()
        {
            return typeof(T).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SqlColumn))).ToArray();
        }
        public static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
