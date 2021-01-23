    List<Tablename> list = db.Tablename
                             .Where(c => c.Devices.devName.ToLower()
                             .Contains((devicename.Trim()).ToLower()))
                             .OrderBy(c => c.dateTime)
                             .Skip(skip)
                             .Take(pageSize).ToList();
