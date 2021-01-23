	public static string ForPlayer(string originalString)
	{
		return
			Regex
				.Replace(originalString, "{(.*?)}", m =>
					Player.player
						.GetType()
						.GetProperty(m.Groups[1].Value)
						.GetValue(Player.player)
						.ToString());
	}
