    public class ProcessWatcher2 : IDisposable {
        public delegate void ProcessCreateEvent(string name, string path);
        public event ProcessCreateEvent ProcessCreated;
        public ProcessWatcher2(string folder) {
            this.folder = folder;
            lock (locker) {
                listeners.Add(this);
                if (watcher == null) Initialize();
            }
        }
        public void Dispose() {
            lock (locker) {
                listeners.Remove(this);
                if (listeners.Count == 0) {
                    watcher.Stop();
                    watcher.Dispose();
                    watcher = null;
                }
            }
        }
        private static void Initialize() {
            var query = new WqlEventQuery(@"SELECT * FROM __InstanceCreationEvent WITHIN 5 WHERE TargetInstance ISA 'Win32_Process'");
            watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += watcher_EventArrived;
            watcher.Start();
        }
        private static void watcher_EventArrived(object sender, EventArrivedEventArgs e) {
            using (var proc = (ManagementBaseObject)e.NewEvent["TargetInstance"]) {
                string name = (string)proc.Properties["Name"].Value;
                string path = (string)proc.Properties["ExecutablePath"].Value;
                lock (locker) {
                    foreach (var listener in listeners) {
                        bool filtered = false;
                        // Todo: implement your filtering
                        //...
                        var handler = listener.ProcessCreated;
                        if (!filtered && handler != null) {
                            handler(name, path);
                        }
                    }
                }
            }
        }
        private static ManagementEventWatcher watcher;
        private static List<ProcessWatcher2> listeners = new List<ProcessWatcher2>();
        private static object locker = new object();
        private string folder;
    }
