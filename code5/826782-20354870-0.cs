    try
            {
    
            }
            catch (Exception e)
            {
                if (e.GetType().Assembly.GetName().Name != "My.Own.Namespace")
                {
                    // this is a .net exception?
                }
            }
