	void Main()
	{
		// Gets rid of any comments that exist in our config file
		IEnumerable<string> textLines = text.Split('\n')
											.Where(line => !line.StartsWith(";"));;
		
		// Converts our 'IEnumerable<string> textLines' back to a string without comments
		string textWithoutComments = string.Join("\n", textLines);
										
		// Retrieves which variables are defined
		// >> BLUE 16711680 
		// >> RED 255 
		Dictionary<string, string> definedVariables = textLines .Where(line => line.StartsWith(@"#define"))
																.Select(line => Regex.Match(line, @"#define ([^ ]*) (.*)"))
																.ToDictionary(match => match.Groups[1].Value, match => match.Groups[2].Value);
									
		// Creates a dictionary of sections that have been defined
		// >> SETTINGS 		File Name
		// >> 		   		File Description
		// >> 				v1.0
		// >>
		// >> SECTION BLUE  N033.56.09.699 W118.25.09.714
		// >>
		// >> SECTION2 RED  N033.56.13.675 W118.24.30.908
		// >>				N033.56.13.675 W118.24.30.908
		// >>      			N033.56.16.034 W118.24.07.905 
		Dictionary<string, string> sectionDictionary = Regex.Matches(textWithoutComments, @"\[([\w]*)\]\n([^\[^\#]*)")
															.Cast<Match>()
															.ToDictionary(match => match.Groups[1].Value, match => match.Groups[2].Value);
		
		
		UserConfiguration userConfig = new UserConfiguration 
		{
			Variables = definedVariables,
			Settings  = sectionDictionary["SETTINGS"],
			Sections  = sectionDictionary.Where(dictionary  => dictionary.Key != "SETTINGS")
										.Select(dictionary  => new {Key = dictionary.Key, Value = Regex.Match(dictionary.Value, @"(\w*) ([^\[]*)")})
										.ToDictionary(anon => anon.Key, anon => new Config 
										{ 
											Name = anon.Value.Groups[1].Value, 
											Value = anon.Value.Groups[2].Value.RemoveWhiteSpace()
										})
		};
		
	}
	public class UserConfiguration
	{
		public Dictionary<string, string> Variables { get; set; }
		public string Settings { get; set; }
		public Dictionary<string, Config> Sections { get; set; }
	}
	
	public class Config
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
	
	public static class Extensions
	{
		public static string RemoveWhiteSpace(this string text)
		{
			var lines = text.Split('\n');
			return string.Join("\n", lines.Select(str => str.Trim()));
		}
	}
	
	const string text = @";This is a comment that should be ignored when parsing 
	
	;Colors in 24-bit format
	#define BLUE 16711680
	#define RED 255
	
	[SETTINGS]
	File Name
	File Description
	v1.0
	
	[SECTION]
	BLUE  N033.56.09.699 W118.25.09.714
	
	[SECTION2]
	RED    N033.56.13.675 W118.24.30.908
		N033.56.13.675 W118.24.30.908
		N033.56.16.034 W118.24.07.905";
