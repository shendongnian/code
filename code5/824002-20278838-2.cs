    string ReplaceUsingDictionary (string src, IDictionary<string, object> replacements) {
    	return Regex.Replace(src, @"{(\w+)}", (m) => {
    		object replacement;
    		var key = m.Groups[1].Value;
    		if (replacements.TryGetValue(key, out replacement)) {
    			return Convert.ToString(replacement);
    		} else {
    			return m.Groups[0].Value;
    		}
    	});
    }
    
    void Main()
    {
    	var replacements = new Dictionary<string, object> {
    		{ "networkid", "WHEEE!!" }
    		// etc.
    	};
    	var src = "http://api.example.com/sale?auth_user=xxxxx&auth_pass=xxxxx&networkid={networkid}&category=b2c&country=IT&pageid={pageid}&programid=133&saleid=1&m={master}&optinfo={optinfo}&publisher={publisher}&msisdn={userId}";
    	var res = ReplaceUsingDictionary(src, replacements);
    	
    	res.Dump();
    }
