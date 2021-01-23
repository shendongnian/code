    public IEnumerable<SearchResult> GetSearchResults()
    {
    	using(var conn = GetYourConnection())
    	{
    		conn.open();
    		using(var cmd = conn.CreateCommand())
    		{
    			cmd.CommandText = GetYourQueryString();
    			using(var reader = cmd.ExecuteReader())
    			{
    				while(reader.Read())
    				{
    					var result = new SearchResult
    					{
    						.... populate from reader...
    					}
    					yield return result;
    				}
    			}			
    		}
    	}
    }
