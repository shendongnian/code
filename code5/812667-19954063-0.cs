	/// <summary>
	/// Compares two XML files to see if they are the same.
	/// </summary>
	/// <returns>Returns true if two XML files are functionally identical, ignoring comments, white space, and child
	/// order.</returns>
	public static bool XMLfilesIdentical(string originalFile, string finalFile)
	{
		var xmldiff = new XmlDiff();
		var r1 = XmlReader.Create(new StringReader(originalFile));
		var r2 = XmlReader.Create(new StringReader(finalFile));
		var sw = new StringWriter();
		var xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented };
		xmldiff.Options = XmlDiffOptions.IgnorePI | 
			XmlDiffOptions.IgnoreChildOrder | 
			XmlDiffOptions.IgnoreComments |
			XmlDiffOptions.IgnoreWhitespace;
		bool areIdentical = xmldiff.Compare(r1, r2, xw);
		string differences = sw.ToString();
		return areIdentical;
	}	
