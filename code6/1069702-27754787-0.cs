    private string ConvertLatitudeToGPS(double Latitude)
        {
            string Direction = "";
            double UnformattedLatitude = Latitude;
            if (Latitude > 0)
            {
                Direction = "N";
            }
            else
            {
                UnformattedLatitude = UnformattedLatitude * -1;
                Direction = "S";
            }
            string GPSString = UnformattedLatitude.ToString("0.0000") + Direction;
            return GPSString;
        }
        private string ConvertLongitudeToGPS(double Longitude)
        {
            string Direction = "";
            double UnformattedLongitude = Longitude;
            if (Longitude > 0)
            {
                Direction = "E";
            }
            else
            {
                UnformattedLongitude = UnformattedLongitude * -1;
                Direction = "W";
            }
            string GPSString = UnformattedLongitude.ToString("0.0000") + Direction;
            return GPSString;
        }
