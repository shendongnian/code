    public class VpnKeeperService : IService {
        private ManualResetEvent shutdownEvent;
        private RasConnectionWatcher connWatcher;
        private Thread thread;
        
        public VpnKeeperService() {
            this.shutdownEvent = new ManualResetEvent(false);
            this.connWatcher = new RasConnectionWatcher();
            this.connWatcher.EnableRaisingEvents = true;
            this.connWatcher.Disconnected += (s, args) => { this.DialUp(); };
        }
        Boolean DialUp() {
            try {
                using(var phoneBook = new RasPhoneBook()) {
                    var name = VpnConfig.GetConfig().ConnectionName;
                    var user = VpnConfig.GetConfig().Username;
                    var pass = VpnConfig.GetConfig().Password;
                    var pbPath = VpnConfig.GetConfig().PhoneBookPath;
                    phoneBook.Open(pbPath);
                    var entry = phoneBook.Entries.FirstOrDefault(e => e.Name.Equals(name));
                    if(entry != null) {
                        using(var dialer = new RasDialer()) {
                            dialer.EntryName = name;
                            dialer.Credentials = new NetworkCredential(user, pass);
                            dialer.PhoneBookPath = pbPath;
                            dialer.Dial();
                        }
                    }
                    else throw new ArgumentException(
                        message: "entry wasn't found: " + name,
                        paramName: "entry"
                    );
                }
                return true;
            }
            catch {
                // log the exception
                return false;
            }
        }
        
        public void Start() {
            this.thread = new Thread(WorkerThreadFunc);
            this.thread.Name = "vpn keeper";
            this.thread.IsBackground = true;
            this.thread.Start();
        }
        public void Stop() {
            this.shutdownEvent.Set();
            if(!this.thread.Join(3000)) {
                this.thread.Abort();
            }
        }
        private void WorkerThreadFunc() {
            if(this.DialUp()) {
                while(!this.shutdownEvent.WaitOne(0)) {
                    Thread.Sleep(1000);
                }
            }
        }
    }
