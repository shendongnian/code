    private double GetAltitudeFromCoordinate() {
        return positionRecord.Coordinate.Altitude == null ? 0.0 : positionRecord.Coordinate.Altitude.Value;
    }
    private double GetAltitudeFromPoint() {
        return positionRecord.Coordinate.Point.Position.Altitude;
    }
    private double GetLatitudeFromCoordinate() {
        return positionRecord.Coordinate.Latitude;
    }
    private double GetLatitudeFromPoint() {
        return positionRecord.Coordinate.Point.Position.Latitude;
    }
    private double GetLongitudeFromCoordinate() {
        return positionRecord.Coordinate.Longitude;
    }
    private double GetLongitudeFromPoint() {
        return positionRecord.Coordinate.Point.Position.Longitude;
    }
