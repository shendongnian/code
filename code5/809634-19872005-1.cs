    CoordinateList list = new CoordinateList();
    list.Coordinate = new List<Coordinate>();
    Coordinate cord = new Coordinate();
    cord.x = "1";
    cord.y = "10";
    list.Coordinate.Add(cord);
    list.Coordinate.Add(cord);
    list.Coordinate.Add(cord);
                
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    String jsonStr = serializer.Serialize(list);
    MessageBox.Show("json:" + jsonStr);
    list = serializer.Deserialize<CoordinateList>(jsonStr);
    foreach (Coordinate c in list.Coordinate)
    {
        MessageBox.Show("x: " + c.x + ", y: " + c.y);
    }
