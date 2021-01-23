    string testsDocumentTemp = testsDocument;
    
    while (DocumentTemp.Contains("/*"))
    {
    	int CutFromPosition = DocumentTemp.IndexOf("/*", 0);
    	int CutToPosition = DocumentTemp.IndexOf("*/", CutFromPosition) - CutFromPosition;
    
    	string s = testsDocumentTemp.Substring(CutFromPosition, CutToPosition);
    
    	var builder = new StringBuilder();
    	builder.Append(' ', s.Length);
    	var result = builder.ToString();
    	
    	DocumentTemp = DocumentTemp.Replace(s, result);
    };
    
    while (DocumentTemp.Contains("////"))
    {
    	int CutFromPosition = DocumentTemp.IndexOf("////", 0);
    	int CutToPosition = DocumentTemp.IndexOf("\n", CutFromPosition) - CutFromPosition;
    
    	string s = testsDocumentTemp.Substring(CutFromPosition, CutToPosition);
    
    	var builder = new StringBuilder();
    	builder.Append(' ', s.Length);
    	var result = builder.ToString();
    	
    	DocumentTemp = DocumentTemp.Replace(s, result);
    };
