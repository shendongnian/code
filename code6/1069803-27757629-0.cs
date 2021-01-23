        private static void Main( string[] args )
        {
            var hostCtrls = USB.GetHostControllers();
            foreach ( var hostCtrl in hostCtrls )
            {
                var hub = hostCtrl.GetRootHub();
                foreach ( var port in hub.GetPorts() )
                {
                    if ( port.IsDeviceConnected && !port.IsHub )
                    {
                        var device = port.GetDevice();
                        Console.WriteLine( "Serial: " + device.DeviceSerialNumber );
                        Console.WriteLine( "Name: " + device.Name );
                        Console.WriteLine( "Speed:  " + port.Speed );
                        Console.WriteLine( "Port:   " + device.PortNumber + Environment.NewLine );
                    }
                }
            }
            Console.ReadLine();
        }
