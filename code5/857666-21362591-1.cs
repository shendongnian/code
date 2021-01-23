    class MySynchronizationProvider : System.Threading.SynchronizationContext {
        public MySynchronizationProvider() {
            base.SetWaitNotificationRequired();
        }
        public override int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout) {
            for (; ; ) {
                int result = MsgWaitForMultipleObjects(waitHandles.Length, waitHandles, waitAll, millisecondsTimeout, 8);
                if (result == waitHandles.Length) System.Windows.Forms.Application.DoEvents();
                else return result;
            }
        }
        [DllImport("user32.dll")]
        private static extern int MsgWaitForMultipleObjects(int cnt, IntPtr[] waitHandles, bool waitAll,
            int millisecondTimeout, int mask);        
    }
