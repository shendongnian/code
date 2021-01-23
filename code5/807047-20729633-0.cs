    SharpMap.Layers.VectorLayer vlay = new SharpMap.Layers.VectorLayer("States");
    //vlay.DataSource = new SharpMap.Data.Providers.ShapeFile("d:\\+PMF\\GIS\\states_ugl.shp", true);
    SharpMap.Data.Providers.SqlServer2008 d = new SharpMap.Data.Providers.SqlServer2008(connectionString, "view1","geom","ID",SharpMap.Data.Providers.SqlServerSpatialObjectType.Geometry,false  ,4326  );
    vlay.DataSource = d;
    mapBox1.Map.Layers.Add(vlay);
    mapBox1.Map.ZoomToExtents();
    // mapBox1.Map.BackColor = Color.BlueViolet;
    mapBox1.Refresh();
 
