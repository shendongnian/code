    public static bool SendSMSMobile(string MobNo, string MessageBody)
            {
                string[] pNo = new string[0];
                bool IsSend = false;
                try
                {
                    string PortNo = "";
                    ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_POTSModem");
                    foreach (ManagementObject mo in mos.Get())
                    {
                        string COMPort = mo["AttachedTo"].ToString();
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
                                Array.Resize(ref pNo, pNo.Length + 1);
                                pNo[pNo.Length - 1] = PortNo;
                            }
                        }
                        catch { }
                        finally { serialPort.Close(); serialPort.Dispose(); }
                    }
    
                    if (PortNo.Trim().Length > 0)
                    {
                        MobNo = MobNo.Replace("(", "");
                        MobNo = MobNo.Replace(")", "");
                        MobNo = MobNo.Replace("+", "");
                        MobNo = MobNo.Replace("-", "");
                        MobNo = MobNo.Replace(",", "");
    
                        if (MobNo.Substring(0, 1) == "0" && MobNo.Length > 5)
                        {
                            MobNo = MobNo.Substring(1, MobNo.Length - 1);
                        }
                        if (MobNo.Trim().Length >= 10 && PortNo.Length > 0)
                        {
                            int MsgLength = Convert.ToInt32(MessageBody.Length);
                            int Q = MsgLength / 160;
                            int R = MsgLength % 160;
                            if (R > 0)
                            {
                                Q = Q + 1;
                            }
                            for (int i = 0; i < Q; i++)
                            {
                                int StartIndex = i * 160;
                                int EndIndex = 160;
                                if (i == Q - 1)
                                {
                                    EndIndex = R;
                                }
                                string Msg = MessageBody.Substring(StartIndex, EndIndex);
                                SerialPort sp = new SerialPort();
    
                                for (int q = 0; q < pNo.Length; q++)
                                {
                                    #region MOBILE
                                    try
                                    {
                                       // System.Windows.Forms.MessageBox.Show(pNo[q].ToString());
                                        char[] arr = new char[1];
                                        arr[0] = (char)26;
                                        sp.PortName = pNo[q].ToString();
                                        sp.BaudRate = 96000;
                                        sp.Parity = Parity.None;
                                        sp.DataBits = 8;
                                        sp.StopBits = StopBits.One;
                                        sp.Handshake = Handshake.XOnXOff;
                                        sp.DtrEnable = true;
                                        sp.RtsEnable = true;
                                        sp.NewLine = Environment.NewLine;
                                        sp.Open();
                                        int mSpeed = 1;
                                        sp.Write("AT+CMGF=1" + Environment.NewLine);
                                        System.Threading.Thread.Sleep(200);
                                        sp.Write("AT+CSCS=GSM" + Environment.NewLine);
                                        System.Threading.Thread.Sleep(200);
                                        sp.Write("AT+CMGS=" + (char)34 + "+91" + MobNo
                                        + (char)34 + Environment.NewLine);
                                        System.Threading.Thread.Sleep(200);
                                        sp.Write(Msg + (char)26);
                                        System.Threading.Thread.Sleep(mSpeed);
                                        IsSend = true;
                                    }
                                    catch 
                                    {
                                        IsSend = false; 
                                    }
                                    finally 
                                    { 
                                        sp.Close(); 
                                        sp.Dispose(); 
                                    }
                                }
                                    #endregion
    
                            }
                        }
                    }
                }
                catch
                {
                    IsSend = false;
                }
                return IsSend;
            }
