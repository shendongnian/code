    public static void RegisterLogClasses()
        {           
            if (!BsonClassMap.IsClassMapRegistered(typeof(Log)))
            {
                BsonClassMap.RegisterClassMap<Log>();                    
            }
    
            if (!BsonClassMap.IsClassMapRegistered(typeof(ErrorLog)))
            {
                BsonClassMap.RegisterClassMap<ErrorLog>();
            }
    
             if (!BsonClassMap.IsClassMapRegistered(typeof(WebErrorLog)))
            {
                BsonClassMap.RegisterClassMap<WebErrorLog>();
            }
    
            if (!BsonClassMap.IsClassMapRegistered(typeof(ActivityLog)))
            {
                BsonClassMap.RegisterClassMap<ActivityLog>();
            }
            BsonSerializer.UseNullIdChecker = true; 
        }        
    }
