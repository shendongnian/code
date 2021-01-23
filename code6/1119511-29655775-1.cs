            startLisning();
        }
        private bool eventHandlerCreated;
        private void startLisning()
        {
            Microsoft.Win32.SystemEvents.SessionSwitch +=new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch1);
            this.eventHandlerCreated = true;
        }
        private void SystemEvents_SessionSwitch1(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock:
                    System.IO.File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "testtest.txt"), "LOCK\t" + DateTime.Now.ToString() + Environment.NewLine);
                    break;
                case SessionSwitchReason.SessionLogon:
                    System.IO.File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "testtest.txt"), "LOGIN\t" + DateTime.Now.ToString() + Environment.NewLine);
                    break;
                case SessionSwitchReason.SessionUnlock:
                    System.IO.File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "testtest.txt"), "UNLOCK\t" + DateTime.Now.ToString() + Environment.NewLine);
                    break;
                case SessionSwitchReason.ConsoleConnect:
                    System.IO.File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "testtest.txt"), "UnlockAfetSwitchUser\t" + DateTime.Now.ToString() + Environment.NewLine);
                    break;
                case SessionSwitchReason.ConsoleDisconnect:
                    System.IO.File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "testtest.txt"), "SwitchUser\t" + DateTime.Now.ToString() + Environment.NewLine);
                    break;
            }
        }
