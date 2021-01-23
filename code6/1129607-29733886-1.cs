    // input values
    double lat = 25; // decimal degrees
    double lon = -10; // decimal degrees
    double bearing = 30; // decimal degrees
    double distance = 1240.8 * 1000; // meters
    // constant
    const double radius = 6371e3; // meters
    // calculation
    // see http://williams.best.vwh.net/avform.htm#LL
    double δ = distance / radius; // angular distance in radians
    double θ = bearing / 180.0 * Math.PI;
    double φ1 = lat / 180.0 * Math.PI;
    double λ1 = lon / 180.0 * Math.PI;
    double φ2 = Math.Asin( Math.Sin(φ1)*Math.Cos(δ) +
                        Math.Cos(φ1)*Math.Sin(δ)*Math.Cos(θ) );
    double λ2 = λ1 + Math.Atan2(Math.Sin(θ)*Math.Sin(δ)*Math.Cos(φ1),
                             Math.Cos(δ)-Math.Sin(φ1)*Math.Sin(φ2));
    λ2 = (λ2+3*Math.PI) % (2*Math.PI) - Math.PI; // normalise to -180..+180°
    // output values
    double lat2 = φ2 * 180.0 / Math.PI; // decimal degrees
    double lon2 = λ2 * 180.0 / Math.PI; // decimal degrees
