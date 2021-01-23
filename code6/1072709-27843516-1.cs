    private void addGeoFence(Geopoint gp, String name, double radius)
    {
        // Always remove the old fence if there is any
        var oldFence = GeofenceMonitor.Current.Geofences.Where(gf => gf.Id == name).FirstOrDefault();
        if (oldFence != null)
            GeofenceMonitor.Current.Geofences.Remove(oldFence);
        Geocircle gc = new Geocircle(gp.Position, radius);
        // Listen for all events:
        MonitoredGeofenceStates mask = 0;
        mask |= MonitoredGeofenceStates.Entered;
        mask |= MonitoredGeofenceStates.Exited;
        mask |= MonitoredGeofenceStates.Removed;
        // Construct and add the fence with a dwelltime of 5 seconds.
        Geofence newFence = new Geofence(new string(name.ToCharArray()), gc, mask, false, TimeSpan.FromSeconds(5), DateTimeOffset.Now, new TimeSpan(0));
        GeofenceMonitor.Current.Geofences.Add(newFence);
    }
