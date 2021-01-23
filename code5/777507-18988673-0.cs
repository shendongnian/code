    public void OnLoaded( object sender, RoutedEventArgs args )
    {
        var xml = new XmlSerializer( typeof( StartupValues ) );
        using( var writer = new StreamWriter( "config_file_path_here.xml" ) )
        {
            xml.Serialize( new StartupValues
                {
                    HasFirstTimePageDisplayed = true
                }, writer.BaseStream );            
        }
    }
