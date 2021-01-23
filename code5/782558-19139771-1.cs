    public void ShowProjectProperties( Project p )
          {
             try
             {
                if ( ( Instance != null ) )
                {
                   string msg = Path.GetFileNameWithoutExtension( p.FullName ) + " has the following properties:" + Environment.NewLine + Environment.NewLine;
    
                   Properties props = p.ConfigurationManager.ActiveConfiguration.Properties;
                   List< string > values = props.Cast< Property >().Select( prop => SafeGetPropertyValue( prop) ).ToList();
                   msg += string.Join( Environment.NewLine, values );
                   MessageDialog.ShowMessage( msg );
                }
             }
             catch ( Exception ex )
             {
                Logger.Info( ex.ToString() );
             }
          }
    
          public string SafeGetPropertyValue( Property prop )
          {
             try
             {
                return string.Format( "{0} = {1}", prop.Name, prop.Value );
             }
             catch ( Exception ex )
             {
                return string.Format( "{0} = {1}", prop.Name, ex.GetType() );
             }
          }
