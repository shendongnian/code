    private static readonly Encoding ContentDispositionHeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
    
    public static string GetWebSafeFileName(string fileName)
    {
    	// We need to convert the file name to ISO-8859-1 due to browser compatibility problems with the Content-Disposition Header (see: http://stackoverflow.com/a/216777/1038611)
    	var webSafeFileName = Encoding.Convert(Encoding.Unicode, ContentDispositionHeaderEncoding, Encoding.Unicode.GetBytes(fileName));
    
    	// Furthermore, any characters not supported by ISO-8859-1 will be replaced by « ? », which is not an acceptable file name character. So we replace these as well.
    	return ContentDispositionHeaderEncoding.GetString(webSafeFileName).Replace('?', '-');
    }
