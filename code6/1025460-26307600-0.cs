        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private static bool IsRunningInConsole()
        {
            return AttachConsole(-1);
        }
