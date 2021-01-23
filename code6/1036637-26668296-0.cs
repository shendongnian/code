		public static class DataReaderExtensions
		{
				public static string GetStringOrNull(this IDataReader dataReader, string columnName)
				{
						try
						{
								object value = dataReader[columnName];
								return (value == null || value == DBNull.Value) ? null : (string)value;
						}
						catch (Exception exception)
						{
								throw new ApplicationException(String.Format("Invalid 'String' data type for column '{0}'", columnName), exception);
						}
				}
				
				...
		}
