        private static readonly Timer batteryCheckTimer = new Timer();
        // This is the method to run when the timer is raised. 
        private static void CheckBattery(Object sender, EventArgs myEventArgs)
        {
            ManagementClass wmi = new ManagementClass("Win32_Battery");
            var allBatteries = wmi.GetInstances();
            foreach (var battery in allBatteries)
            {
                int batteryLevel = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                if (batteryLevel < 25)
                {
                    JARVIS.Speak("Warning, Battery level has dropped below 25%");
                }
            }
        }
        public static int Main()
        {
            batteryCheckTimer.Tick += new EventHandler(CheckBattery);
            batteryCheckTimer.Interval = 900000;
            batteryCheckTimer.Start();
            return 0;
        }
