		// Used from SqlServerCeDriver as well
		public static void SetVariableLengthParameterSize(IDbDataParameter dbParam, SqlType sqlType)
		{
			SetDefaultParameterSize(dbParam, sqlType);
			// no longer override the defaults using data from SqlType, since LIKE expressions needs larger columns
			// https://nhibernate.jira.com/browse/NH-3036
			//if (sqlType.LengthDefined && !IsText(dbParam, sqlType) && !IsBlob(dbParam, sqlType))
			//{
			//	dbParam.Size = sqlType.Length;
			//}
			if (sqlType.PrecisionDefined)
			{
				dbParam.Precision = sqlType.Precision;
				dbParam.Scale = sqlType.Scale;
			}
		}
