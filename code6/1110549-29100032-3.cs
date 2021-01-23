    public IMySql Factory(bool isremote)
    		{
    
    			if (isremote)
    				return new RemoteMySQL();
    			
    			else
    				return new MySQL();
    		}
