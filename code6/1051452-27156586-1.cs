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
				var s = string.Join("", str.Skip(j * len).Take(len));
				if (!string.IsNullOrEmpty(s))
					strings.Add(s);
			}
			if (remainder > 0)
			{
				var s = string.Join("", str.Skip(div * len).Take(remainder));
				if (!string.IsNullOrEmpty(s))
					strings.Add(s);
			}
			return string.Join(Environment.NewLine, strings.ToArray());
		}
		public static string rtrim(string input)
		{
			while (input.EndsWith(Environment.NewLine))
				input = input.Remove(input.Length - Environment.NewLine.Length);
			return input.TrimEnd(' ');
		}
