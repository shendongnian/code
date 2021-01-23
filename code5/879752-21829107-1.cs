            List<ActivityLog> list = db.ActivityLog.Where(c => devicename == "" || c.Devices.devName.ToLower().Contains(devicename.ToLower()))
                                                   .Where(c => user == "" || c.Users.uName.ToLower().Contains(user.ToLower()))
                                                   .Where(c => alarm == "" || c.AlarmCodes.aName.ToLower().Contains(alarm.ToLower()))
                                                   .OrderBy(c => c.dateTime).Skip(skip).Take(pageSize).ToList();
  
