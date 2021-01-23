    public string SendUssdRequest(string request)
        {
            log.DebugFormat("Sending USSD Request {0}", request);
            string result = "";
            try
            {
                IProtocol protocol = comm.GetProtocol();
                string gottenString = protocol.ExecAndReceiveMultiple("AT+CUSD=1," + request + ",15");
                result = gottenString;
                int i = 0;
                if (!gottenString.Contains("\r\n+CUSD: 2"))
                {
                    bool receiving = false;
                    do
                    {
                        receiving = protocol.Receive(out gottenString);
                        result += gottenString;
                        ++i;
                    } while (receiving);
                }
                result = result.Replace("\r\n", "");
                
                result = result.Replace("+CUSD: 2,", "");
                result = result.Replace(",15", "");
                log.DebugFormat("{1} - USSD Response is:  {0}", result,SenderNumber);
                return result;
            }
            catch(Exception ex) 
            {
                log.Error(ex);
            }
            finally
            {
                
                comm.ReleaseProtocol();
            }
            return "";
        }
