	static string Decode(string input)
	{
		var sb = new StringBuilder();
		int position = 0;
		var bytes = new List<byte>();
		while(position < input.Length)
		{
			char c = input[position++];
			if(c == '\\')
			{
				if(position < input.Length)
				{
					c = input[position++];
					if(c == 'x' && position <= input.Length - 2)
					{
						var b = Convert.ToByte(input.Substring(position, 2), 16);
						position += 2;
						bytes.Add(b);
					}
					else
					{
						AppendBytes(sb, bytes);
						sb.Append('\\');
						sb.Append(c);
					}
					continue;
				}
			}
			AppendBytes(sb, bytes);
			sb.Append(c);
		}
		AppendBytes(sb, bytes);
		return sb.ToString();
	}
	private static void AppendBytes(StringBuilder sb, List<byte> bytes)
	{
		if(bytes.Count != 0)
		{
			var str = System.Text.Encoding.UTF8.GetString(bytes.ToArray());
			sb.Append(str);
			bytes.Clear();
		}
	}
