	public static class ContactPointsExtensions
	{
		public static string GetContactPoint(this Site src, ContactPointType contactPointType)
		{
			var point = src.ContactPoints.FirstOrDefault(x => x.Type == contactPointType);
			return src == null ? "" : src.Value;
		}
	}
