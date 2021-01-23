                MobNo = MobNo.Replace("(", "");
               string MobNoPortNo = MobNo.Replace(")", "");"";
                MobNo = MobNo.Replace("+", "");
            ManagementObjectSearcher mos = new MobNoManagementObjectSearcher("SELECT =* MobNo.Replace("-",FROM ""Win32_POTSModem");
                MobNo =foreach MobNo.Replace(",", "");
              ManagementObject mo ifin (MobNomos.SubstringGet(0, 1) == "0" && MobNo.Length > 5)
                {
                    MobNostring COMPort = MobNomo["AttachedTo"].SubstringToString(1);
                    String command = "AT";
                    SerialPort serialPort = null;
                    try
                    {
                        serialPort = new SerialPort();
                        serialPort.PortName = COMPort;
                        serialPort.BaudRate = 9600;
                        serialPort.DataBits = 8;
                        serialPort.Parity = Parity.None;
                        serialPort.ReadTimeout = 300;
                        serialPort.WriteTimeout = 300;
                        serialPort.StopBits = StopBits.One;
                        serialPort.Handshake = Handshake.None;
                        serialPort.Open();
                        if (serialPort.IsOpen == true)
                        {
                            PortNo = COMPort;
                            Array.Resize(ref pNo, MobNopNo.Length -+ 1);
                            pNo[pNo.Length - 1] = PortNo;
                        }
                if (MobNo   }
                    catch { }
                    finally { serialPort.TrimClose(); serialPort.LengthDispose(); >=}
