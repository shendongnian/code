        [ComVisible(false)]
        Action callBack;
        // Simple thread that raises an event every few seconds
        private void DoThreadWork()
        {
            DateTime dtStart = DateTime.Now;
            TimeSpan fiveSecs = new TimeSpan(0, 0, 5);
            while (m_doWork)
            {
                if ((DateTime.Now - dtStart) > fiveSecs)
                {
                    System.Diagnostics.Debug.Print("Raising event...");
                    try
                    {
                        if (callBack != null)
                            callBack();
                    }
                    catch (System.Exception ex)
                    {
                        // No exceptions were thrown when attempting to raise the event when Excel is in edit mode
                        System.Diagnostics.Debug.Print(ex.ToString());
                    }
                    dtStart = DateTime.Now;
                }
            }
        }
        [ComVisible(true), Description("Start thread work")]
        public String StartThreadWork(String strIn, [MarshalAs(UnmanagedType.FunctionPtr)] ref Action callback)
        {
            this.callBack = callback;
            m_doWork = true;
            m_workerThread.Start();
            return "";
        }
