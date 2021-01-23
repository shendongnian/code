        public string GetFirmwareVersion()
        {
            var f = subject.Where(s => Regex.Match(s, @"...").Success)
                           .Take(1)
                           .PublishLast();
            var c = f.Connect();
            // send command for firmware version
            port.Send(new byte[] { 0x9 });
            var data = f.Timeout(TimeSpan.FromSeconds(10)).Wait();
            c.Dispose();
            return data;
        }
        public Config GetConfiguration()
        {
            using (var subject2 = new Subject<Config>())
            {
                var f = subject.Where(s => Regex.Match(s, @"...").Success)
                               .Select(s =>
                               {
                                   // get data via xmodem
                                   Thread.Sleep(500);
                                   var modem = new Modem(this.port._serialPort);
                                   var bytes = modem.XModemReceive(true);
                                   subject2.OnNext(new DeviceConfig(bytes));
                                   subject2.OnCompleted();
                                   return s;
                               })
                               .Take(1)
                               .PublishLast();
                var c = f.Connect();
                // send command for firmware version
                port.Send(new byte[] { 0x2 });
                var ret = subject2.Timeout(TimeSpan.FromSeconds(60)).Wait();
                c.Dispose();
                return ret;
            }
        }
