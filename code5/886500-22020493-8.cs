    var ping = new System.Net.NetworkInformation.Ping();
    var pingReply = await ping.SendPingAsync("www.google.com");
    Console.WriteLine("{0} {1} {2}",pingReply.Address, 
                                    pingReply.RoundtripTime, 
                                    pingReply.Status);
