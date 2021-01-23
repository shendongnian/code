    using namespace System.Diagnostics;
    ...
        public static bool WaitForInputIdle(IntPtr hWnd, int timeout = 0) {
            int pid;
            int tid = GetWindowThreadProcessId(hWnd, out pid);
            if (tid == 0) throw new ArgumentException("Window not found");
            var tick = Environment.TickCount;
            do {
                if (IsThreadIdle(pid, tid)) return true;
                System.Threading.Thread.Sleep(15);
            }  while (timeout > 0 && Environment.TickCount - tick < timeout);
            return false;
        }
        
        private static bool IsThreadIdle(int pid, int tid) {
            Process prc = System.Diagnostics.Process.GetProcessById(pid);
            var thr = prc.Threads.Cast<ProcessThread>().First((t) => tid == t.Id);
            return thr.ThreadState == ThreadState.Wait &&
                   thr.WaitReason == ThreadWaitReason.UserRequest;
        }
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int pid);
