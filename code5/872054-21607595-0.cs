        using (var context = new ApplicationDbContext())
        {
            context.Configuration.LazyLoadingEnabled=lazyLoadingEnabled;
            var client = (from _client in context.Client
                          where _client.ApplicationUserId == userId
                          select _client).FirstOrDefault();
            return client; //at this point, your context is gone, and no 
            //navigational properties will be loaded onto your client object, 
            //even if you try to navigate them. You may even get exceptions if
            //attempting to navigate to some properties.
        }
