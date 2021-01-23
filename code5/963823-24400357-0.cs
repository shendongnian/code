	public static class ConnectionDetails
	{
		public static string UserName;
		public static string Password;
		
		public static string GetAccessConnectionString(string filepath)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", filepath);
			if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
				sb.Append("User Id=admin;Password=;");
			else
				sb.AppendFormat("User Id={0};Password={1};", UserName, Password);
			return sb.ToString();
		}
	}
