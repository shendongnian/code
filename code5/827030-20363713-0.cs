	///      Literal .
	///      Literal .
	///  [2]: A numbered capture group. [.+?]
	///      Any character, one or more repetitions, as few as possible
	///  First or last character in a word
	///  
	///
	/// </summary>
	public Regex MyRegex = new Regex(
		  "\\b([^.]+)\\.\\.(.+?)\\b",
		RegexOptions.IgnoreCase
		| RegexOptions.CultureInvariant
		| RegexOptions.Compiled
		);
	// This is the replacement string
	public string MyRegexReplace = "$2@$1_LNK";
	//// Replace the matched text in the InputText using the replacement pattern
        string result = MyRegex.Replace(InputText,MyRegexReplace);
