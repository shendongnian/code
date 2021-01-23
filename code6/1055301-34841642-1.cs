    BasicGeoposition waypoint1 = new BasicGeoposition() { Latitude = lat1, Longitude = long1 };
    BasicGeoposition waypoint2 = new BasicGeoposition() { Latitude = lat2, Longitude = long2 };
    BasicGeoposition waypoint3 = new BasicGeoposition() { Latitude = lat3, Longitude = long3 };
    List<Geopoint> positions = new List<Geopoint>();
    positions.Add(new Geopoint(waypoint1));
    positions.Add(new Geopoint(waypoint2));
    positions.Add(new Geopoint(waypoint3));
    // Get the route between the points.
    MapRouteFinderResult routeResult = await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(positions);
