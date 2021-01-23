      linestring.Coordinates = coordinates;
      Placemark placemark = new Placemark();
      placemark.Name = "ryan";
      placemark.Geometry = linestring;
      // Create Style with id
      SharpKml.Dom.LineStyle lineStyle = new SharpKml.Dom.LineStyle();
      lineStyle.Color = Color32.Parse("ff0000ff");
      lineStyle.Width = 2;
      Style roadStyle = new Style();
      roadStyle.Id = "RoadStyle";
      roadStyle.Line = lineStyle;
      // Add style to document
      document.AddStyle(roadStyle);
      // Specify style for your placemark by url
      placemark.StyleUrl = new Uri("#RoadStyle", UriKind.Relative);
      document.AddFeature(placemark);
