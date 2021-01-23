    using (var db = new MyDbContext()) 
    {
        var results = db.GetResultsFromDatabase();
        int take = 100;
        int processed = 0;
        
        while(processed < results.Count()) 
        {
            var set = results.Skip(processed).Take(take);
            set.ForEach(s => {  
                // update the date
            }
    
            processed += take;
        }
        db.SubmitChanges();
    }
