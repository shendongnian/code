        if (Config.Config.type == ControlType.Type1) 
        {
            var s = syncService as type1Service;
            
            if (s == null)
            {
                throw new ArgumentException (
                    string.Format ("Expected type: {0}, Actual type: {1}", 
                        typeof(type1Service), 
                        syncService.GetType ()));
            }
        }
