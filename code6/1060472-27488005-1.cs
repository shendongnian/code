    var log = new LogEntry
    {
        ExtendedProperties = new Dictionary<string, object>
        {
            {
                "Context", new LoggingContext
                {
                    DeclaringTypeName = "EndpointConfig"
                }
            }
        }
    };
    
    collection.Insert(log);
