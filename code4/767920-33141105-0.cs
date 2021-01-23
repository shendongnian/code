        void ThreadEngine_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker objBackgroundWorker = sender as BackgroundWorker;
            try
            {
                mSerialPort = new SerialPort(GetPortName(mPortName), DefaultBaudRate, Parity.Even, 7, StopBits.Two);
                mSerialPort.Open();
                objBackgroundWorker.ReportProgress(0);
                while (objBackgroundWorker.CancellationPending == false)
                {
                    if (IOScanner(objBackgroundWorker, false) == true)
                    {
                        ScannerStationData();
                        IsReady = true;
                        IsError = false;
                    }
                    else
                    {
                        IsReady = false;
                        IsError = true;
                    }
                    Thread.Sleep(1);
                }
                // Performs last scan before thread closing
                if (objBackgroundWorker.CancellationPending == true)
                {
                    IOScanner(objBackgroundWorker, true);
                }
                mSerialPort.Close();
                mSerialPort = null;
                e.Result = null;
            }
            catch (Exception objErr)
            {
                string sMessage = string.Format("PlcService.ThreadEngine_DoWork Err={0}", objErr.Message);
                mLogSysService.AddItem(sMessage);
                IsError = true;
            }
        }
