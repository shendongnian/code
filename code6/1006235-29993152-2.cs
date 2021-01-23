    if (string.IsNullOrEmpty(uuid))
    {
      uuid = NetworkInterface.GetAllNetworkInterfaces()
      .Where(ni => ni.OperationalStatus == OperationalStatus.Up)
      .FirstOrDefault()
      .GetPhysicalAddress().ToString();
    }
