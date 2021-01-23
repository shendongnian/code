	public static string ToBase64(this string self)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(self);
		return Convert.ToBase64String(bytes);	
	}
	public static string FromBase64(this string self)
	{
		byte[] bytes = Convert.FromBase64String(self);
		return Encoding.UTF8.GetString(bytes);
	}
