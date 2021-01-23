    var query = (from v in context.Vehicles
                             //left join vehicleAttributes
                             join va in context.VehicleAttributes on v.VehicleId equals va.VehicleId into vAttributes
                             from vehicleAttributes in vAttributes.DefaultIfEmpty()
                             where v.FleetId == fleetId
                             orderby vehicleAttributes.Value ascending 
                             select new { v, vehicleAttributes });
