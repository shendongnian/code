    public class DebugEventArgs : EventArgs {
        public bool Attached { get; set; }
    }
    class Watcher {
        public event EventHandler<DebugEventArgs>  DebuggerChanged;
        
        public Watcher() {
            new Thread(() => {
                while (true) {
                    var last = System.Diagnostics.Debugger.IsAttached;
                    while (last == System.Diagnostics.Debugger.IsAttached) {
                        Thread.Sleep(250);
                    }
                    OnDebuggerChanged();
                }
            }){IsBackground = true}.Start();
        }
    
        protected void OnDebuggerChanged() {
           var handler = DebuggerChanged;
           if (handler != null) handler(this, new DebugEventArgs { Attached = System.Diagnostics.Debugger.IsAttached });
        }
    }
