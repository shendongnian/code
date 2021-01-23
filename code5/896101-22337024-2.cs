    private void ParsePosition() {
        GpsInformation newPosition = new GpsInformation();
        newPosition.TimeStamp = DateTime.Now;
        try {
            if ( UseCoordinate )
                ParseLatLonFromCoordinate( newPosition );
            else
                ParseLatLonFromPoint( newPosition );
        } catch ( MissingMethodException ) {
            // The Geolocation API must not be supported.
            throw new NotSupportedException( "This machine does not support the Windows Geolocation API." );
        }
        // . . .
    }
