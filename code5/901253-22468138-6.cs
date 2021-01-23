    public void Save(Item item)
    {   
       // add logic that the prior asynchonous call to SaveToDatabase is complete
       // if not wait for it to complete 
       // LastValueCache will possible be replaced so you need last item in the database 
       // the time for a lock is not really a factor as it will be faster than the prior update 
       Item cached = LastValueCache;
       if (cached == null || item.Stamp > cached.Stamp)
       {
           LastValueCache = item;
       }
       // make the next a task or background so it does not block    
       SaveToDatabase(item);
    }
