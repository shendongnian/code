     public void ReceiveFaxNow()
        {
            try
            {
                var device = nws.faxSrv.GetDevices().GetEnumerator();
                device.MoveNext();
                FaxDevice dev = (FaxDevice)device.Current;
                if (dev != null)
                {
                    dev.AnswerCall();
                }
            }
            catch (Exception e)
            {
            }
        }
