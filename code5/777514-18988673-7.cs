    public void OnStartup( ... ) // I forget what the method signature for this is
    {
        bool displayFirstPage = true;
        var xml = new XmlSerializer( typeof( StartupValues ) );
        using( var reader= new StreamReader( "config_file_path_here.xml" ) )
        {
            StartupValues values = xml.Deserialize( reader.BaseStream ) as StartupValues;
            displayFirstPage = values.HasFirstTimePageDisplayed;
        }
        if( displayFirstPage )
        {
            // display the page
        }
        else
        {
            // display a different page
        }
    }
