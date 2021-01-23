                System.IO.Ports.SerialPort port = null;
                port = new System.IO.Ports.SerialPort(Program.CashDrawerPort);
                port.PortName = Program.CashDrawerPort;
                port.BaudRate = 9600;
                port.Parity = System.IO.Ports.Parity.None;
                port.DataBits = 8;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.RtsEnable = true;
                try
                {
                    port.Open();
                    if (port.IsOpen)
                    {
                        port.Write("B");
                    }
                    else
                    {
                    }
                    port.Close();
                }
                catch (Exception exceptionMessage)
                {
                }
