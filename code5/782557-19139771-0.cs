      public string GetCommandLineArguments( Project p )
      {
         string returnValue = null;
         try
         {
            if ( ( Instance != null ) )
            {
               Properties props = p.ConfigurationManager.ActiveConfiguration.Properties;
               try
               {
                  returnValue = props.Item( "StartArguments" ).Value.ToString();
               }
               catch
               {
                  returnValue = props.Item( "CommandArguments" ).Value.ToString();
                  // for c++
               }
            }
         }
         catch ( Exception ex )
         {
            Logger.Info( ex.ToString() );
         }
         return returnValue;
      }
