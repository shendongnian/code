    public class SqlTableCreator
    {
        #region Instance Variables
        private SqlConnection _connection;
        public SqlConnection Connection {
            get { return _connection; }
            set { _connection = value; }
        }
 
        private SqlTransaction _transaction;
        public SqlTransaction Transaction {
            get { return _transaction; }
            set { _transaction = value; }
        }
 
        private string _tableName;
        public string DestinationTableName {
            get { return _tableName; }
            set { _tableName = value; }
        }
        #endregion
 
        #region Constructor
        public SqlTableCreator() { }
        public SqlTableCreator(SqlConnection connection) : this(connection, null) { }
        public SqlTableCreator(SqlConnection connection, SqlTransaction transaction) {
            _connection = connection;
            _transaction = transaction;
        }
        #endregion
 
        #region Instance Methods
        public object Create(DataTable schema) {
            return Create(schema, null);
        }
        public object Create(DataTable schema, int numKeys) {
            int[] primaryKeys = new int[numKeys];
            for (int i = 0; i < numKeys; i++) {
                primaryKeysIdea = i;
            }
            return Create(schema, primaryKeys);
        }
        public object Create(DataTable schema, int[] primaryKeys) {
            string sql = GetCreateSQL(_tableName, schema, primaryKeys);
 
            SqlCommand cmd;
            if (_transaction != null && _transaction.Connection != null)
                cmd = new SqlCommand(sql, _connection, _transaction);
            else
                cmd = new SqlCommand(sql, _connection);
 
            return cmd.ExecuteNonQuery();
        }
 
        public object CreateFromDataTable(DataTable table) {
            string sql = GetCreateFromDataTableSQL(_tableName, table);
 
            SqlCommand cmd;
            if (_transaction != null && _transaction.Connection != null)
                cmd = new SqlCommand(sql, _connection, _transaction);
            else
                cmd = new SqlCommand(sql, _connection);
 
            return cmd.ExecuteNonQuery();
        }
        #endregion
 
        #region Static Methods
 
        public static string GetCreateSQL(string tableName, DataTable schema, int[] primaryKeys) {
            string sql = "CREATE TABLE " + tableName + " (\n";
 
            // columns
            foreach (DataRow column in schema.Rows) {
                if (!(schema.Columns.Contains("IsHidden") && (bool)column["IsHidden"]))
                    sql += column["ColumnName"].ToString() + " " + SQLGetType(column) + ",\n";
            }
            sql = sql.TrimEnd(new char[] { ',', '\n' }) + "\n";
 
            // primary keys
            string pk = "CONSTRAINT PK_" + tableName + " PRIMARY KEY CLUSTERED (";
            bool hasKeys = (primaryKeys != null && primaryKeys.Length > 0);
            if (hasKeys) {
                // user defined keys
                foreach (int key in primaryKeys) {
                    pk += schema.Rows[key]["ColumnName"].ToString() + ", ";
                }
            }
            else {
                // check schema for keys
                string keys = string.Join(", ", GetPrimaryKeys(schema));
                pk += keys;
                hasKeys = keys.Length > 0;
            }
            pk = pk.TrimEnd(new char[] { ',', ' ', '\n' }) + ")\n";
            if (hasKeys) sql += pk;
            sql += ")";
 
            return sql;
        }
 
        public static string GetCreateFromDataTableSQL(string tableName, DataTable table) {
            string sql = "CREATE TABLE [" + tableName + "] (\n";
            // columns
            foreach (DataColumn column in table.Columns) {
                sql += "[" + column.ColumnName + "] " + SQLGetType(column) + ",\n";
            }
            sql = sql.TrimEnd(new char[] { ',', '\n' }) + "\n";
            // primary keys
            if (table.PrimaryKey.Length > 0) {
                sql += "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED (";
                foreach (DataColumn column in table.PrimaryKey) {
                    sql += "[" + column.ColumnName + "],";
                }
                sql = sql.TrimEnd(new char[] { ',' }) + "))\n";
            }
 
            return sql;
        }
 
        public static string[] GetPrimaryKeys(DataTable schema) {
            List<string> keys = new List<string>();
 
            foreach (DataRow column in schema.Rows) {
                if (schema.Columns.Contains("IsKey") && (bool)column["IsKey"])
                    keys.Add(column["ColumnName"].ToString());
            }
 
            return keys.ToArray();
        }
 
        // Return T-SQL data type definition, based on schema definition for a column
        public static string SQLGetType(object type, int columnSize, int numericPrecision, int numericScale) {
            switch (type.ToString()) {
                case "System.String":
                    return "VARCHAR(" + ((columnSize == -1) ? 255 : columnSize) + ")";
 
                case "System.Decimal":
                    if (numericScale > 0)
                        return "REAL";
                    else if (numericPrecision > 10)
                        return "BIGINT";
                    else
                        return "INT";
 
                case "System.Double":
                case "System.Single":
                    return "REAL";
 
                case "System.Int64":
                    return "BIGINT";
 
                case "System.Int16":
                case "System.Int32":
                    return "INT";
 
                case "System.DateTime":
                    return "DATETIME";
 
                default:
                    throw new Exception(type.ToString() + " not implemented.");
            }
        }
 
        // Overload based on row from schema table
        public static string SQLGetType(DataRow schemaRow) {
            return SQLGetType(schemaRow["DataType"],
                                int.Parse(schemaRow["ColumnSize"].ToString()),
                                int.Parse(schemaRow["NumericPrecision"].ToString()),
                                int.Parse(schemaRow["NumericScale"].ToString()));
        }
        // Overload based on DataColumn from DataTable type
        public static string SQLGetType(DataColumn column) {
            return SQLGetType(column.DataType, column.MaxLength, 10, 2);
        }
        #endregion
    }
