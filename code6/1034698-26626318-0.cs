	/// <summary>
	/// URL-encodes the path section of a URL string and returns the encoded string.
	/// </summary>
	/// <param name="input">The text to URL path encode</param>
	/// <returns>The URL path encoded text.</returns>
	[System.Diagnostics.CodeAnalysis.SuppressMessage(
		"Microsoft.Design",
		"CA1055:UriReturnValuesShouldNotBeStrings",
		Justification = "This does not return a full URL so the return type can be a string.")]
	public static string UrlPathEncode(string input)
	{
		if (string.IsNullOrEmpty(input)) 
		{ 
			return input; 
		} 
		// DevDiv #211105: We should make the UrlPathEncode method encode only the path portion of URLs. 
		string schemeAndAuthority; 
		string path; 
		string queryAndFragment; 
		bool validUrl = UriUtil.TrySplitUriForPathEncode(input, out schemeAndAuthority, out path, out queryAndFragment);
		if (!validUrl) 
		{ 
			// treat as a relative URL, so we might still need to chop off the query / fragment components 
			schemeAndAuthority = null; 
			UriUtil.ExtractQueryAndFragment(input, out path, out queryAndFragment); 
		} 
		return schemeAndAuthority + HtmlParameterEncoder.UrlPathEncode(path, Encoding.UTF8) + queryAndFragment; 
	}
