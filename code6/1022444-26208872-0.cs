	public static class Extensions
	{
		public static string ToNullIfEmpty(this string @this)
		{
			return String.IsNullOrEmpty(@this) ? null : @this;
		}
	}
