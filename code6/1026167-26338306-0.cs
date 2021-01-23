    var query = from device in deviceInfo
                            group device by new { Android = device.OS.Contains("Android"), iOS = device.OS.Contains("iOS") } into deviceGroup
                            select new
                            {
                                AndroidCount = deviceGroup.Key.Android ? deviceGroup.Count() : 0,
                                iOSCount = deviceGroup.Key.iOS ? deviceGroup.Count() : 0
                            };
    
    
                Console.WriteLine("User | Count");
                Console.WriteLine("--------------");
                foreach (var dev in query)
                {
                    if (dev.AndroidCount != 0)
                        Console.WriteLine("{0} | {1}", "Android", dev.AndroidCount);
                    if(dev.iOSCount!=0)
                        Console.WriteLine("{0} | {1}", "iOS", dev.iOSCount);
                }
