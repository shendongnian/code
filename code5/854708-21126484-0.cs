    [JsonProperty(PropertyName = "imdbVotes")]
    public string ImdbVotes { get; set; }
    
    public int ImdbVotesInt 
    { 
    	get 
    	{
    		int result;
    		if (int.TryParse(ImdbVotes, 
    				NumberStyles.AllowThousands,
    				CultureInfo.InvariantCulture, 
    				out result))					
    			return result; 	// parse is successful, use 'result'
    		else
    			return 0; 		// parse is unsuccessful, return whatever default value works for you		
    	}
    }
