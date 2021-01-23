                    while (true)
                    {
                        string msgDXCC;
                        string band;
                        Thread.Sleep(100);
                        var spot = socket.Receive(Encoding.UTF8);
                        if (spot != "")
                        {
                            spotMsg = JObject.Parse(spot);
                            msgDXCC = (string)spotMsg["Dxcc"];
                            band = (string)spotMsg["Band"];
                            var keyPresent = o.Property(msgDXCC);
                            if (keyPresent != null)
                            {
                                string qsoStatus = (string)o[msgDXCC][band];
                                if (qsoStatus == null)
                                {
                                    //add record
                                    
                                }
                                else
                                {
                                    //do nothing
                                }
                            }
                        }
                    }
