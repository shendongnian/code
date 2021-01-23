    [AttributeUsage(AttributeTargets.Property,Inherited=false)]
        public class SqlColumn : Attribute
        {
            public SqlColumn(string columnName, Type valueType, bool primaryKey)
            {
                _ColumnName = columnName;
                _ValueType = valueType;
                _PrimaryKey = primaryKey;
            }
    
            private string _ColumnName;
            private Type _ValueType;
            private bool _PrimaryKey;
    
            public string ColumnName
            {
                get
                {
                    return this._ColumnName;
                }
                set
                {
                    _ColumnName = value;
                }
            }
    
            public Type ValueType
            {
                get
                {
                    return this._ValueType;
                }
                set
                {
                    _ValueType = value;
                }
            }
    
            public bool PrimaryKey
            {
                get
                {
                    return this._PrimaryKey;
                }
                set
                {
                    _PrimaryKey = value;
                }
            }
    
        }
    
