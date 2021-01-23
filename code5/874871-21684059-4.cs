    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    class STAThread : IDisposable {
        public STAThread() {
            using (mre = new ManualResetEvent(false)) {
                thread = new Thread(() => {
                    Application.Idle += Initialize;
                    Application.Run();
                });
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                mre.WaitOne();
            }
        }
        public void BeginInvoke(Delegate dlg, params Object[] args) {
            if (ctx == null) throw new ObjectDisposedException("STAThread");
            ctx.Post((_) => dlg.DynamicInvoke(args), null);
        }
        public object Invoke(Delegate dlg, params Object[] args) {
            if (ctx == null) throw new ObjectDisposedException("STAThread");
            object result = null;
            ctx.Send((_) => result = dlg.DynamicInvoke(args), null);
            return result;
        }
        protected virtual void Initialize(object sender, EventArgs e) {
            ctx = SynchronizationContext.Current;
            mre.Set();
            Application.Idle -= Initialize;
        }
        public void Dispose() {
            if (ctx != null) {
                ctx.Send((_) => Application.ExitThread(), null);
                ctx = null;
            }
        }
        private Thread thread;
        private SynchronizationContext ctx;
        private ManualResetEvent mre;
    }
