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
