	public static string ForPlayer(string originalString)
	{
		return
			Regex
				.Matches(originalString, "{(.*?)}")
				.Cast<Match>()
				.Select(x => x.Groups[1].Value)
				.Select(x => new
				{
					From = x,
					To = Player.player
						.GetType()
						.GetProperty(x)
						.GetValue(Player.player)
						.ToString()
				})
				.Aggregate(originalString, (a, x) => a.Replace("{" + x.From + "}", x.To));
	}
