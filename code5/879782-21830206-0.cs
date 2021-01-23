    var headers = GetHeaders(content.First());
    var result = from entry in content.Skip(1)
    				group entry by new {Code = entry[headers.code], Book = entry[headers.book] } into grp
    				select new {
    					Book = grp.Key.Book,
    					Code = grp.Key.Code,
    					Total = grp.Sum(x => ParseInt(x[headers.columnToSum]))
    				};
    
    public dynamic GetHeaders(List<string> headersList){
    	IDictionary<string, object> headers = new ExpandoObject();
    	for (int i = 0; i < headersList.Count; i++)
    		headers[headersList[i]] = i;		
    	
    	return headers;
    }
    
    public int ParseInt(string s){
    	int i;
    	if (int.TryParse(s, out i)) 
    		return i; 
    	
    	return 0;	
    }
