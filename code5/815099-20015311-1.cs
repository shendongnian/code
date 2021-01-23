     public static GeoCoordinate ConvertGeoCoOrdinate(Geocoordinate geoCooridinate)
            {
                return new GeoCoordinate(
                    geoCooridinate.Latitude,
                    geoCooridinate.Longitude,
                    geoCooridinate.Altitude ?? double.NaN,
                    geoCooridinate.Accuracy,
                    geoCooridinate.AltitudeAccuracy ?? double.NaN,
                    geoCooridinate.Speed ?? double.NaN,
                    geoCooridinate.Heading ?? double.NaN);
            }
