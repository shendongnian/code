    private void Form1_load(object sender, EventArgs e)
    {
    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
    gMapControl1.DragButton = MouseButtons.Left;
    GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
    gMapControl1.Position = new PointLatLng(LATITUDE,LONGITUDE);
    gMapControl1.Zoom = 9;
    }
