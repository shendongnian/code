    private new const NumberStyles Style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
    var value = GetValue();
    var unknownGeoCoordinate = GeoCoordinate.Unknown;
    if (string.IsNullOrWhiteSpace(value))
        return unknownGeoCoordinate;
    // The value of location in the Sitecore field is a pipe-separated string
    // the first value is the latitude followed by pipe "|", then longitude
    // Example: 67.2890989|14.401694
    var latLng = value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
    if (latLng.Count() != 2)
        return unknownGeoCoordinate;
    double latitude;
    double longitude;
    if (!double.TryParse(latLng.First(), Style, null, out latitude) || !double.TryParse(latLng.Last(), Style, null, out longitude))
    return unknownGeoCoordinate;
