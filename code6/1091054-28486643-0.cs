    public void AddGeoFence(Geopoint gp, String name, double radius)
    {
        // Always remove the old fence if there is any
        var oldFence = GeofenceMonitor.Current.Geofences.Where(gf => gf.Id == name).FirstOrDefault();
        if (oldFence != null)
            GeofenceMonitor.Current.Geofences.Remove(oldFence);
        Geocircle gc = new Geocircle(gp.Position, radius);
        // Just listen for exit geofence
        MonitoredGeofenceStates mask = 0;
        mask |= MonitoredGeofenceStates.Exited;
        // Construct and add the fence
        Geofence newFence = new Geofence(new string(name.ToCharArray()), gc, mask, false, TimeSpan.FromSeconds(7), DateTimeOffset.Now, new TimeSpan(0));
        GeofenceMonitor.Current.Geofences.Add(newFence);
    }
