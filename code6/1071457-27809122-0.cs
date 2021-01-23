    public static class DbDataRecordExtensions
    {
		public static bool GetBoolean(this DbDataRecord rec, string fieldName)
		{
			var index = rec.GetOrdinal(fieldName);
			var value = rec.GetValue(index);
			if (value is bool || value is Boolean)
			{
				return (bool)value;
			}
			else if (value is SByte || value is sbyte)
			{
				return (sbyte)value == 1;
			}
			else
			{
				return rec.GetInt64(index) == 1;
			}
		}
    }
