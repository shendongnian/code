    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static SqlDecimal TRY_CONVERT_DECIMAL(SqlString input)
    {
        decimal decimalOutput;
        return !input.IsNull && decimal.TryParse(input.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimalOutput) ? decimalOutput : SqlDecimal.Null;
    }
    
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static SqlInt64 TRY_CONVERT_BIGINT(SqlString input)
    {
        long bigIntOutput;
        return !input.IsNull && long.TryParse(input.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out bigIntOutput) ? bigIntOutput : SqlInt64.Null;
    }
    
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static SqlDateTime TRY_CONVERT_DATE(SqlString input)
    {
        var minSqlDateTime = new DateTime(1753, 1, 1, 0, 0, 0, 0);
        var maxSqlDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 0);
        DateTime dateTimeOutput;
        return !input.IsNull && DateTime.TryParse(input.Value, CultureInfo.CreateSpecificCulture("en-GB"), DateTimeStyles.None, out dateTimeOutput) &&
            dateTimeOutput >= minSqlDateTime && dateTimeOutput <= maxSqlDateTime ? dateTimeOutput : SqlDateTime.Null;
    }
    
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static SqlString TRY_CONVERT_NVARCHAR(SqlString input)
    {
        return input.IsNull || string.IsNullOrWhiteSpace(input.Value) ? SqlString.Null : input.Value;
    }
