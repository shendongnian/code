    var document = new Document();
    document.Id = "null";
    document.Open = true;
    document.Name = "MyDoc";
    
    ///Style 1
    SharpKml.Dom.LineStyle lineStyle = new SharpKml.Dom.LineStyle();
    lineStyle.Color = Color32.Parse("FFE67800");
    lineStyle.Width = 12;
    
    SharpKml.Dom.PolygonStyle PolyStyle = new SharpKml.Dom.PolygonStyle();
    PolyStyle.Color = Color32.Parse("FFE67800");
    
    SharpKml.Dom.Style SimpleStyle = new SharpKml.Dom.Style();
    SimpleStyle.Id = "Style1";
    SimpleStyle.Line = lineStyle;
    SimpleStyle.Polygon = PolyStyle;
    document.AddStyle(SimpleStyle);
    
    
    //Style 2
    SharpKml.Dom.LineStyle lineStyle2 = new SharpKml.Dom.LineStyle();
    lineStyle2.Color = Color32.Parse("FF1478F0");
    lineStyle2.Width = 12;
    
    SharpKml.Dom.PolygonStyle PolyStyle2 = new SharpKml.Dom.PolygonStyle();
    PolyStyle2.Color = Color32.Parse("FF1478F0");
    
    SharpKml.Dom.Style SimpleStyle2 = new SharpKml.Dom.Style();
    SimpleStyle2.Id = "Style2";
    SimpleStyle2.Line = lineStyle2;
    SimpleStyle2.Polygon = PolyStyle2;
    document.AddStyle(SimpleStyle2);
    
    ///
    //Drawing shapes
    //
    List<di_vector> list = new List<di_vector>();
    list.Add(new di_vector { longitude = 49.5993894, latitude = 6.1064789 });
    list.Add(new di_vector { longitude = 49.5995181, latitude = 6.1064977 });
    list.Add(new di_vector { longitude = 49.5994511, latitude = 6.106491 });
    list.Add(new di_vector { longitude = 49.5994398, latitude = 6.1066076 });
    list.Add(new di_vector { longitude = 49.5995128, latitude = 6.106617 });
    list.Add(new di_vector { longitude = 49.599372, latitude = 6.1065969 });
    
    Placemark placemark = new Placemark();
    placemark = CreateLineString(list);
    placemark.StyleUrl= new Uri("#Style1", UriKind.Relative);
    document.AddFeature(placemark);
    
    list.Clear();
    list.Add(new di_vector { longitude = 49.5993645, latitude = 6.1066354 });
    list.Add(new di_vector { longitude = 49.5995079, latitude = 6.1067373 });
    list.Add(new di_vector { longitude = 49.5993523, latitude = 6.1067722 });
    list.Add(new di_vector { longitude = 49.5994314, latitude = 6.1067561 });
    list.Add(new di_vector { longitude = 49.5994366, latitude = 6.1066877 });
               
    //Placemark placemark = new Placemark();
    placemark = CreateLineString(list);
    placemark.StyleUrl = new Uri("#Style2", UriKind.Relative);
    document.AddFeature(placemark);
    
    var kml = new Kml();
    kml.Feature = document;
    KmlFile kmlFile = KmlFile.Create(kml, true);
    
    var serializer = new Serializer();
    serializer.Serialize(document);
    Console.WriteLine(serializer.Xml);
    
    string output = serializer.Xml.Replace("Document", "kml");
