            var document = new Document();
            document.Id = "null";
            document.Open = true;
            document.Name = "MyDoc";
            LineString linestring = new LineString();
            linestring.AltitudeMode = AltitudeMode.Absolute;
            linestring.Extrude = true;
            linestring.Tessellate = true;
            CoordinateCollection coordinates = new CoordinateCollection();
            foreach (DataRow dr in dt.Rows) 
            {
                double lon = double.Parse(dr["Longitude"].ToString());
                double lat = double.Parse(dr["Latitude"].ToString());
                double alt = pt.alt.Parse(dr["Altitude"].ToString());;
                coordinates.Add(new Vector(lat, lon, alt));
            }
            linestring.Coordinates = coordinates;
            Placemark placemark = new Placemark();
            placemark.Name = filename;
            placemark.Visibility = false;
            placemark.Geometry = linestring;
            SharpKml.Dom.LineStyle lineStyle = new SharpKml.Dom.LineStyle();
            lineStyle.Color = Color32.Parse("7f00ffff");
            lineStyle.Width = 4;
            SharpKml.Dom.PolygonStyle PolyStyle = new SharpKml.Dom.PolygonStyle();
            PolyStyle.Color = Color32.Parse("7f00ff00");
            Style SimpleStyle = new Style();
            SimpleStyle.Id = "yellowLineGreenPoly";
            SimpleStyle.Line = lineStyle;
            SimpleStyle.Polygon = PolyStyle;
            document.AddStyle(SimpleStyle);
            placemark.StyleUrl = new Uri("#yellowLineGreenPoly", UriKind.Relative);
            document.AddFeature(placemark);
            var kml = new Kml();
            kml.Feature = document;
            KmlFile kmlFile = KmlFile.Create(kml, true);
