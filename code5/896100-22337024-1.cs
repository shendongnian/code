    private void ParseLatLonFromCoordinate( GpsInformation newPosition ) {
        // We assume this is a Windows 8.0 machine that doesn't have the Point property.
        newPosition.Position.Latitude  = positionRecord.Coordinate.Latitude;
        newPosition.Position.Longitude = positionRecord.Coordinate.Longitude;
    }
    private void ParseLatLonFromPoint( GpsInformation newPosition ) {
        // The system must not support the Coordinate.Latitude & Longitude properties any more.
        newPosition.Position.Latitude  = positionRecord.Coordinate.Point.Position.Latitude;
        newPosition.Position.Longitude = positionRecord.Coordinate.Point.Position.Longitude;
    }
