     string UserName = "SomeLogin";     
     PrincipalContext domainContext = 
        new PrincipalContext(ContextType.Domain, "...", "... );            
     using ( var searcher = 
                new PrincipalSearcher( new UserPrincipal( domainContext ) 
                         { SamAccountName = UserName } ) )
     {
         var principal = UserPrincipal i in searcher.FindAll().ToList().FirstOrDefault();
         if ( principal != null )
         {
            // this is what you look for
            bool enabled = principal.Enabled; 
         }
     }
