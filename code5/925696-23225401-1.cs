     [AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
        public class SqlTable : Attribute
        {
    
            public SqlTable(string TableName)
            {
                this._TableName = TableName;
            }
    
            protected String _TableName;
            public String TableName
            {
                get
                {
                    return this._TableName;
                }
            }    
        }
