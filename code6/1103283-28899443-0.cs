    if(map != null)
    {
        RunOnUiThread (new Action (delegate { map.Clear (); });
        foreach(ReceiverPointTable item in dataManager.GetAllReceiverPoints ())
        {
            var markerOpt1 = new MarkerOptions();
            markerOpt1.SetTitle("Test point");
            markerOpt1.SetPosition (new LatLng (item.LATITUDE, item.LONGITUDE));
            markerOpt1.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(
                                          BitmapDescriptorFactory.HueMagenta));
            RunOnUiThread (new Action (delegate { map.AddMarker(markerOpt1); }));
        }
    }
