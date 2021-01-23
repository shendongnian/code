        protected bool WriteDMWord(int iAddress, int[] aryValues)
        {
            bool bRetValue = true;
            try
            {
                mSerialPort.NewLine = "\r";
                mSerialPort.ReadTimeout = DefaultTimeout;
                string sTxData = HostLinkProtocol.BuildWriteDMWord(iAddress, aryValues);
                mSerialPort.WriteLine(sTxData);
                string sRxData = string.Empty;
                sRxData = mSerialPort.ReadLine();
                if (HostLinkProtocol.ParseWriteDMWord(sRxData) == true)
                {
                    bRetValue = true;
                }
            }
            catch (Exception objErr)
            {
                Console.WriteLine("WriteDMWord [{0}]", objErr.Message);
                bRetValue = false;
            }
            return bRetValue;
        }
