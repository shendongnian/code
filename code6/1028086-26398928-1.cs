        protected void Application_Start()
        {
            // remove the one that caches instances by default
            FilterProviders.Providers.Remove( 
               FilterProviders.Providers.Where( 
                  p => p is FilterAttributeFilterProvider ).FirstOrDefault() );
            // replace with one that doesn't
            FilterProviders.Providers.Add( new FilterAttributeFilterProvider( false ) );
        }
