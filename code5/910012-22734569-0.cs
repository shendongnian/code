    var sData = (from log in db.GSMDeviceLogs
                 join log2 in db.GSMDeviceLogs on log.GSMDeviceLogId equals log2.GSMDeviceLogId - 1
                 where log.Vehicle.VehicleId == vehicleId
                     && log.IgnitionOn != log2.IgnitionOn
                 orderby log.DateTimeOfLog ascending
                 select new { LogId = log.,
                              Ignition = log.IgnitionOn,
                              Date = log.DateTimeOfLog,
                              Location = log.Location }).ToList();
