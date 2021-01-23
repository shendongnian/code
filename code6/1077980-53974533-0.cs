		public static Color ToColorFromTitleCaseLetters(this string fullName)
		{
			if (fullName.IsNullOrEmpty()) return Color.Blue;
			try
			{
				string result = string.Concat(Regex
					.Matches(fullName, "[A-Z]")
					.OfType<Match>()
					.Select(match => match.Value));
				int x = 1;
				if (result.Length > 1)
				{
					 x =(int)result[0] + (int)result[1];
				}
				//https://stackoverflow.com/questions/14204827/ms-chart-for-net-predefined-palettes-color-list
				string[] colors = new[]
				{
					"008000", "0000FF", "800080", "800080", "FF00FF", "008080", "FFFF00", "808080", "00FFFF", "000080",
					"800000", "FF3939", "7F7F00", "C0C0C0", "FF6347", "FFE4B5","33023","B8860B","C04000","6B8E23","CD853F","C0C000","228B22","D2691E","808000","20B2AA","F4A460","00C000","8FBC8B","B22222","843A05","C00000"
				};
				int interval = ((int)'Z' *2) / colors.Length;
				int index = x / interval;
				return Color.FromHex(colors[index]);
			}
			catch
			{
			}
			return Color.Blue;
		}
