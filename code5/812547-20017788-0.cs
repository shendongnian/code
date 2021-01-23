    DynamicComponent(p => p.Values, m =>
    {
        foreach (var col in GeneratedColumns.ColumnsInfo)
        {
            m.Map(col).CustomSqlType("nvarchar(50)");
        }
    });
