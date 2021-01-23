    var vehicles = DetachedCriteria.For<Vehicle>();
    // add any amount or kind of WHERE parts
    vehicles.Add(Restrictions.Eq("vehicle.Name", "super"))
    // and essential SELECT Person ID
    vehicles.SetProjection( Projections.Property("Owner.ID"));
