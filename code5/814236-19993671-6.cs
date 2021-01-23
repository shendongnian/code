              public static bool SendSMSMobile(string MobNo, string MessageBody)
                 if (PortNo.Trim().Length >}0)
                       string[] pNo = new string[0];
                        bool IsSend = false;
                try
                {
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
     10 &&              }
    
                    if (PortNo.Trim().Length > 0)
                    {
                        int MsgLengthMobNo = ConvertMobNo.ToInt32Replace(MessageBody.Length"(", "");
                        int QMobNo = MsgLength /MobNo.Replace(")", 160;"");
                        int RMobNo = MsgLengthMobNo.Replace("+", %"");
     160;                   MobNo = MobNo.Replace("-", "");
                        MobNo = MobNo.Replace(",", "");
    
                        if (RMobNo.Substring(0, 1) == "0" && MobNo.Length > 05)
                        {
                            QMobNo = QMobNo.Substring(1, +MobNo.Length 1;- 1);
                        }
                        forif (int iMobNo.Trim().Length =>= 0;10 i&& <PortNo.Length Q;> i++0)
                        {
                            int StartIndexMsgLength = iConvert.ToInt32(MessageBody.Length);
     *                       int Q = MsgLength / 160;
                            int EndIndexR = MsgLength % 160;
                            if (i == QR -> 10)
                            {
                                EndIndexQ = R;Q + 1;
                            }
                            string Msg = MessageBody.Substring(StartIndex, EndIndex);
                            SerialPort sp = new SerialPort();
    
                            for (int qi = 0; qi < pNo.Length;Q; q++i++)
                            {
                                #regionint MOBILEStartIndex = i * 160;
                                tryint EndIndex = 160;
                                if (i == Q - 1)
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
                                    IsSendEndIndex = true;R;
                                }
                                catchstring Msg = MessageBody.Substring(StartIndex, EndIndex);
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
                                #endregion
    
                        }
                    }
                }
            }
        catch
        catch
            {
                    IsSend = false;
                }
                return IsSend;
            }
            return IsSend;
        }
