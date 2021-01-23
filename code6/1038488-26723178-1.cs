    class MyDataParameter : IDataParameter {
        private readonly AdoNetAppenderParameter wrapped;
        public MyDataParameter (AdoNetAppenderParameter w) {
            wrapped = w;
        }
        DbType DbType {
            get { return wrapped.DbType; }
            set { wrapped.DbType = value; }
        }
        ... // And so on
    }
