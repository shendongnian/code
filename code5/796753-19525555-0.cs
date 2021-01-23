    public bool ItemExists( string itemToCheck )
    {
        // Firstly checking if the item is already in the cache
        if( this.cache.ItemExists( itemToCheck ) )
        {
            return true;
        }
        // Trying to load the item into the cache. If it doesn't exist, returning false
        return this.cache.tryLoadItem( itemToCheck );
    }
