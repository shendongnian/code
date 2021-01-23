        public static void StartWatching()
        {
            StopWatching(); //add this line
            try
            {
                WqlEventQuery query = new WqlEventQuery("Select * From __InstanceCreationEvent Within 2 Where TargetInstance Isa 'Win32_Process'");
                watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
                watcher.Start();
            }
            catch (Exception err)
            {
                string t = "err " + err.ToString();
            }
        }
