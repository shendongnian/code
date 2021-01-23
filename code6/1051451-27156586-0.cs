		public static string base64_encode(string str)
		{
			return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
		}
		public static string chunk_split(string str, int len)
		{
			var strings = new List<string>();
			var div = str.Length % len;
			var remainder = len - div * len;
			if (div == 1)
			{
				return string.Join("", str.Take(len));
			}
			for (var j = 0; j < div; j++)
			{
				strings.Add(string.Join("", str.Skip(j * len).Take(len)));
			}
			if (remainder > 0)
			{
				strings.Add(string.Join("", str.Skip(div * len).Take(remainder)));
			}
			return string.Join(Environment.NewLine, strings.ToArray());
		}
		public static string rtrim(string input)
		{
			return input.TrimEnd(' ');
		}
