    async public void DrawRoomsonMap(Map Mapa)
            {
               ... //Response Reading
                
                //used the: https://github.com/GeoJSON-Net/GeoJSON.Net
                var reader = new GeoJsonReader();
                 
                //read the json map features to a list with the help of GeoJsnoReader
                var features2 = (Geo.IO.GeoJson.FeatureCollection)reader.Read(jsonText);
                var list = features2.Features.ToList();
    
                //clear map elements
                Mapa.MapElements.Clear();
    
                //my own implementation for getting elements with a specific property, in this case a lever of some value 
                foreach (var item in list.Where(x=> x.Properties["level"].ToString() == _currentLevel.ToString()))
                {
                    //converted the geometry property of each item to a Wkt string, and extracted the polygons to and array
                    var b = item.Geometry.ToWktString();
                    b = b.Replace("MULTIPOLYGON", "").Replace("(((", "").Replace(")))", "").TrimStart(' ');
                    var c = b.Split(',');
                    
                    //Created a MapPolygon object and GeoCoordinates collection
                    MapPolygon polygon = new MapPolygon();
                    GeoCoordinateCollection coordenadas = new GeoCoordinateCollection();
                    //added the coordinates to the polygon
                    foreach (var coor in c)
                    {
                        var x = coor.TrimStart(' ');
                        var lat = x.Split(' ')[0].Replace(".",",");
                        var lon = x.Split(' ')[1].Replace(".", ",");
    
                        double latitude = double.Parse(lat);
                        double longitude = double.Parse(lon);
    
                        coordenadas.Add(new GeoCoordinate(longitude, latitude));
                    }
    
                    //polygon properties and added to the map control.
                    polygon.Path = coordenadas;
                    polygon.FillColor = fixColor(item.Properties["bpart"].ToString());
                    polygon.StrokeColor = Colors.White;
                    polygon.StrokeThickness = 3;                
                    Mapa.MapElements.Add(polygon);
                }
            }
