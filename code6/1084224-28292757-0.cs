	private List<string> limitFontList(List<string> fontList, string word) {
		// Create a new list
		var newFontList = new List<string>();
		// Go through each element in the list
		foreach (var fontFamily in fontList) {
			// If the elment contains the word
			if (fontFamily.ToLower().Contains(word.ToLower())) {
				// Add it to the new list
				newFontList.Add(fontFamily);
			}
		}
		// Return the new list if anything was put in it, otherwise the original list.
		return newFontList.Count > 0 ? newFontList :  fontList;
	}
getFontName:
    private string getFontName(Font font) {
		// Holds the font we want to return. This will be the original name if
		// a better one cannot be found
		string fontWanted = font.FontFamily.Name;
		// Create a new Media.FontFamily
		var family = new System.Windows.Media.FontFamily(fontWanted);
		/// Get the base font name
		string baseFont = ""; // Holds the name
		/* FamilyNames.Values will holds the base name, but it's in a collection
		** and the easiest way to get it is to use a foreach. To the best of my
		** knowledge, there is only ever one value in Values.
		** E.g. If the font set is Segoe UI SemiBold Italc, gets Segoe UI.
		*/
		foreach(var baseF in family.FamilyNames.Values){
			baseFont = baseF;
		}
		// If the baseFont is what we were passed in, then just return
		if(baseFont == fontWanted) {
			return fontWanted;
		}
		// Get the typeface by extracting the basefont from the name.
		// Trim removes any preceeeding spaces.
		string fontTypeface = fontWanted.Substring(baseFont.Length).Trim();
		// Will hold all of the font names to be checked.
		var fontNames = new List<string>();
			
			
		// Go through all of the available typefaces, and add them to the list
		foreach (var typeface in family.FamilyTypefaces) {
			foreach(var fn in typeface.AdjustedFaceNames) {
				fontNames.Add(baseFont + " " + fn.Value);
			}
		}
		// Limit the list to elements which contain the specified typeface
		fontNames = limitFontList(fontNames, fontTypeface);
		// If the font is bold, and the original name doesn't have bold in it (semibold?)
		if(!baseFont.ToLower().Contains("bold") && font.Bold) {
			fontNames = limitFontList(fontNames, "bold");
		}
		// In a similar manner for italics
		if (!baseFont.ToLower().Contains("italic") && font.Italic) {
			fontNames = limitFontList(fontNames, "italic");
		}
		// If we have only one result left
		if(fontNames.Count == 1) {
			return fontNames[0];
		}
		// Otherwise, we can't accurately determine what the long name is,
		// So hope whatever the short name is will work.
		return fontWanted;
	}
