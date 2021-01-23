	public static long ParseAsUnixTimestampSeconds(String s) {
		DateTime unixEpoch=new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		var pattern="ddd MMM d HH:mm:ss yyyy";
		var dt=DateTime.ParseExact(
			s, pattern, CultureInfo.InvariantCulture, DateTimeStyles.None);
		return (long)(dt-unixEpoch).TotalSeconds;
	}
