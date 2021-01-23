        private void subscribeToProcessStartEvents()
        {
            string pol = "3";
            string queryString = "SELECT * FROM __InstanceCreationEvent WITHIN " + pol + " WHERE TargetInstance ISA 'Win32_Process'";
            ManagementEventWatcher watcher = new ManagementEventWatcher(queryString);
            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            try
            {
                watcher.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Occurred: " + e.ToString());
            }
        }
        public void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject proc = ((ManagementBaseObject)e.NewEvent["TargetInstance"]);
            MessageBox.Show(DateTime.Now.ToString() + ": Process " + proc["Name"] + " with Path: " + proc["ExecutablePath"] + " Has Started");
            //To see the arguments used:
            string commandLineString = proc["CommandLine"].ToString();
        }
