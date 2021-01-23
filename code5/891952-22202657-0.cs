    /// <summary>
    /// Look for the given font name (not file name) in the supplied PdfReader's AcroForm dictionary.
    /// </summary>
    /// <param name="reader">An open PdfReader to search for fonts in.</param>
    /// <param name="fontName">The font's name as listed in the PDF.</param>
    /// <returns>A BaseFont object if the font is found or null.</returns>
    static BaseFont findFontInForm(PdfReader reader, String fontName) {
        //Get the document's acroform dictionary
        PdfDictionary acroForm = (PdfDictionary)PdfReader.GetPdfObject(reader.Catalog.Get(PdfName.ACROFORM));
    
        //Bail if there isn't one
        if (acroForm == null) {
            return null;
        }
    
        //Get the resource dictionary
        var DR = acroForm.GetAsDict(PdfName.DR);
    
        //Get the font dictionary (required per spec)
        var FONT = DR.GetAsDict(PdfName.FONT);
    
        //Look for the actual font and return it
        return findFontInFontDict(FONT, fontName);
    }
    
    /// <summary>
    /// Helper method to look at a specific font dictionary for a given font string.
    /// </summary>
    /// <remarks>
    /// This method is a helper method and should not be called directly without knowledge of
    /// the internals of the PDF spec.
    /// </remarks>
    /// <param name="fontDict">A /FONT dictionary.</param>
    /// <param name="fontName">The font's name as listed in the PDF.</param>
    /// <returns>A BaseFont object if the font is found or null.</returns>
    static BaseFont findFontInFontDict(PdfDictionary fontDict, string fontName) {
        //This code is adapted from http://osdir.com/ml/java.lib.itext.general/2004-09/msg00018.html
        foreach (var internalFontName in fontDict.Keys) {
            var internalFontDict = (PdfDictionary)PdfReader.GetPdfObject(fontDict.Get(internalFontName));
            var baseFontName = (PdfName)PdfReader.GetPdfObject(internalFontDict.Get(PdfName.BASEFONT));
            //// compare names, ignoring the initial '/' in the baseFontName
            if (baseFontName.ToString().IndexOf(fontName) == 1) {
                var iRef = (PRIndirectReference)fontDict.GetAsIndirectObject(internalFontName);
                if (iRef != null) {
                    return BaseFont.CreateFont(iRef);
                }
            }
        }
    
        return null;
    }
