    void Main()
    {
    	string _js = @"<<SCRIPT>alert(""Hack+"");//<</SCRIPT>";
    	
    	// Break it down into bytes
    	byte[] _bytes = UTF8Encoding.UTF8.GetBytes(_js);	
    	
    	// Use the single unicode character literal representation of the characters wanting to strip
    	//		'+' = +, etc...
    	byte[] _sanatizedBytes = _bytes.Where(b => b != '+').ToArray();
    	
    	// Dump the bytes back into a UTF8 string
    	string sanitizedJavascript = UTF8Encoding.UTF8.GetString(_sanatizedBytes);
    	
    	string _safeJavascript = Microsoft.Security.Application.Encoder.HtmlEncode(sanitizedJavascript);
    	
    	string decode = HttpUtility.HtmlDecode(_safeJavascript);
    	
    	var txtdecoded = new TextBox() { Text = decode};	
    	
    }
