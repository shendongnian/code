    private string GetOrCreateAlbumId(FacebookClient api, string profileId, string name, int albumNumber = 0)
    {
    	var fullName = albumNumber == 0 ? name : string.Format("{0}_{1}", name, albumNumber);
    
    	dynamic d = api.Get(string.Format("{0}/albums", profileId), new { fields = "id,name,count", limit = "9999" });
    	var data = (JsonArray)((JsonObject)d).Values.First();
    
    	try
    	{
    		if (data == null || data.Any() == false || data.FirstOrDefault(x => ((JsonObject)x)["name"].ToString() == fullName) == null)
    		{
    			// no such album - create new one
    			var param = new { name = fullName };
    			var album = api.Post(string.Format("{0}/albums", profileId), param);
    
    			return ((JsonObject)album)["id"].ToString();
    		}
    		else
    		{
    			var album = (JsonObject)data.First(x => ((JsonObject)x)["name"].ToString() == fullName);
    
    			int imageCount = 0;
    			if (album.ContainsKey("count"))
    			{
    				int.TryParse(album["count"].ToString(), out imageCount);
    			}
    
    			if (imageCount > 500)
    			{
    				albumNumber++;
    
    				return this.GetOrCreateAlbumId(api, profileId, name, albumNumber);
    			}
    
    			return album["id"].ToString();
    		}
    	}
    	catch (Exception ex)
    	{
    		var msg = string.Format("Data: {0}\r\nAlbum Name: {1}\r\nAlbum number: {2}", data, name, albumNumber);
    		throw new Exception(msg, ex);
    	}
    }
