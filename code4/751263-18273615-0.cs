            //We Open the proxy to let connections happen
            objProxy.Open();
            if (performHandshake())
            {
                IsConnected = true;
                DelayedShutdownBool = false;
                //While connected, the thread keeps the client alive
                finished.WaitOne();
                if (DelayedShutdownBool)
                {
                    System.Threading.Thread.Sleep(500);
                    objProxy.Close();
                    objConfiguration = null;
                    IsConnected = false;
                }
            }
