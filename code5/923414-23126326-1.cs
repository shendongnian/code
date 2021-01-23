    public class Code
    {
        public string Id { get;set; }
        public string Extension { get;set; }
        public string CodeStr { get; set; }
        public Code(string code)
        {
    	    CodeStr = code;
    	    Id = code.Remove(code.Length - 1);
            Extension = code.Substring(code.Length - 1);
        }
    }
    private List<Code> CodeList(IEnumerable<string> codes)
	{
	    var result = new List<Code>();
	    foreach(string str in codes)
	    {
	        var code = new Code(str);
	        if (result.Exists(x => x.Id == code.Id))
	        {
	            var items = result.Where(x => x.Id == code.Id && code.Extension == "0").ToList() ;
	            foreach (var item in items)
	            {
	                result.Remove(item);
	            }
		        if (code.Extension != "0")
	                result.Add(code);
	        }
	        else
	        {
	            result.Add(code);
	        }
	    }
	    return result;
	}
