	public static class ContactPointsExtensions
	{
		public static string GetContactPoint(this IEnumerable<ContactPoint> src, ContactPointType contactPointType)
		{
			var point = src.FirstOrDefault(x => x.Type == contactPointType);
			return src == null ? "" : src.Value;
		}
	}
