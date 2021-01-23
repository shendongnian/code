            List<ActivityLog> list = db.ActivityLog.Where(c => string.IsNullOrWhiteSpace(devicename) || c.Devices.devName.ToLower().Contains(devicename.ToLower()))
                                                   .Where(c => string.IsNullOrWhiteSpace(user) || c.Users.uName.ToLower().Contains(user.ToLower()))
                                                   .Where(c => string.IsNullOrWhiteSpace(alarm) || c.AlarmCodes.aName.ToLower().Contains(alarm.ToLower()))
                                                   .OrderBy(c => string.IsNullOrWhiteSpace(pageSize) || c.dateTime).Skip(skip).Take(pageSize).ToList();
  
