    var  ips = NetworkInterface.GetAllNetworkInterfaces()
               .Where(inf => inf.NetworkInterfaceType != NetworkInterfaceType.Loopback)
               .Where(inf => inf.OperationalStatus == OperationalStatus.Up)
               .Select(x => new{
                    name = x.Name,
                    ips = x.GetIPProperties().UnicastAddresses.Select(y=>y.Address)
                          .ToList()
               })
               .ToList();
