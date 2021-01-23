	protected static void SetDefaultParameterSize(IDbDataParameter dbParam, SqlType sqlType)
	{
		switch (dbParam.DbType)
		{
			case DbType.AnsiString:
			case DbType.AnsiStringFixedLength:
				dbParam.Size = MaxSizeForLengthLimitedAnsiString;
				break;
