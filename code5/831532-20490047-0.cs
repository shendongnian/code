            private static YourAppContainer _dbContainer;
            public static YourAppContainer DbContext
            {
                get
                {
                    try
                    {
                        return _dbContainer ?? (_dbContainer = new YourAppContainer());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex);
                    }
                }
            }
