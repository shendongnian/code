    JObject jsonObject = new JObject
    {
    	{ "Date", DateTime.Now },
    	{ "Album", "Me Against The World" },
    	{ "Year", 1995 }, 
    	{ "Artist", new JObject
    		{
    			{ "Name", "2Pac" },
    			{ "Age", 28 }
    		}
    	}
    };
