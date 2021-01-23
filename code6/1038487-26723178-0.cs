    class MyDataParameter : IDataParameter {
        DbType DbType { get; set; }
        ParameterDirection Direction { get; set; }
        bool IsNullable { get; }
        string ParameterName { get; set; }
        string SourceColumn { get; set; }
        DataRowVersion SourceVersion { get; set; }
        object Value { get; set; }
    }
    var res = initial.Select(
        p => new MyDataParameter {
            DbType = p.DbType
        ,   ParameterName = p.ParameterName
        ,   ... // and so on
        }
    ).Cast<IDataParameter>();
