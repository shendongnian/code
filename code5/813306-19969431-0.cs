    var nis = System.Net.NetworkInformation
                .NetworkInterface.GetAllNetworkInterfaces()
                .Select(s =>
                    string.Format("{0}: {1}", s.Name,
                    string.Join(";", s.GetIPProperties().GatewayAddresses.Select(ss => ss.Address.ToString()))));
    Gateway_Address.Text = string.Join("\r\n", nis);
