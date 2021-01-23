    internal void Commit() 
    {
        // Ignore many details here...
        
        this._innerConnection.ExecuteTransaction(...);
    
    	if (!this.IsZombied && !this._innerConnection.IsYukonOrNewer)
    	{
            // Zombie() method will set _innerConnection to null
    		this.Zombie();
    	}
    	else
    	{
    		this.ZombieParent();
    	}
    
        // Ignore many details here...
    }
    
    internal void Zombie()
    {
    	this.ZombieParent();
    
    	SqlInternalConnection innerConnection = this._innerConnection;
    
        // Set the _innerConnection to null
    	this._innerConnection = null;
    
    	if (innerConnection != null)
    	{
    		innerConnection.DisconnectTransaction(this);
    	}
    }
