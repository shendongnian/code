    List<BasicGeoposition> basicPositions = new List<BasicGeoposition>();
    basicPositions.Add(new BasicGeoposition() { Latitude = 50, Longitude = 3 });
    basicPositions.Add(new BasicGeoposition() { Latitude = 55, Longitude = 8 });
    basicPositions.Add(new BasicGeoposition() { Latitude = 42, Longitude = 0 });
    
    this.Map.TrySetViewBoundsAsync(GeoboundingBox.TryCompute(basicPositions), null, MapAnimationKind.Default);
