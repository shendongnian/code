    public static string[] ColumnSqlTypes
    {
        get
        {
            return new[]
            {
                "nvarchar(50)",
                "int",
                "nvarchar(255)",
                "nvarchar(255)",
                "nvarchar(255)"
            };
        }
    }
    public static Type[] ColumnTypes
    {
        get
        {
            return new[]
            {
                typeof(string),
                typeof(Int32),
                typeof(string),
                typeof(string),
                typeof(string)
            };
        }
    }
