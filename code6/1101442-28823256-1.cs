    public class Token
	{
		public string TokenToReplace { get; set; }
		public string EntityField { get; set; }
		public string Modifier { get; set; }
		public Token(string tag)
		{
			this.TokenToReplace = tag;
			this.EntityField = Regex.Match(tag, @"[\w\d]+\.[\w\d]+\.[\w\d]+").Value;
			this.Modifier = tag.Contains("|") ? Regex.Match(tag.Split('|').Last(), @"[\w\d]+").Value : null;
		}
	}
