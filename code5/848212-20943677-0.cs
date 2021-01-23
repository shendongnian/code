    string ds = "8:15";
    string[] parts = ds.Split(new[] { ':' });
    DateTime dt = new DateTime(
                       DateTime.Now.Year,
                       DateTime.Now.Month,
                       DateTime.Now.Day,
                       Convert.ToInt32(parts[0]), 
                       Convert.ToInt32(parts[1]));
