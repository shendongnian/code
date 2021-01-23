	public static partial class Extensions
	{
		public static string GetNullableString(this IDataReader self, int ordinal)
		{
			return self.IsDBNull(ordinal) ? null : self.GetString(ordinal);
		}
	}
