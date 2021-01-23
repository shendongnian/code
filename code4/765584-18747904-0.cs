        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();
        // Delegate type to be used as the Handler Routine for SCCH
        delegate Boolean ConsoleCtrlDelegate(CtrlTypes CtrlType);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);
        // Enumerated type for the control messages sent to the handler routine
        enum CtrlTypes : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);
        /// <summary>
        /// Immediately halts all running processes under this ProcessManager's control.
        /// </summary>
        public static void HaltAllProcesses()
        {
            for (int i = 0; i &lt; runningProcesses.Count; i++)
            {
                Process p = runningProcesses[i];
                uint pid = (uint)p.Id;
                //This does not require the console window to be visible.
                if (AttachConsole(pid))
                {
                    //Disable Ctrl-C handling for our program
                    SetConsoleCtrlHandler(null, true);
                    GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);
                    //Must wait here. If we don't and re-enable Ctrl-C
                    //handling below too fast, we might terminate ourselves.
                    p.WaitForExit(2000);
                    FreeConsole();
                    //Re-enable Ctrl-C handling or any subsequently started
                    //programs will inherit the disabled state.
                    SetConsoleCtrlHandler(null, false);
                }
                if (!p.HasExited)
                { //for console-driven processes, this won't even do anything... (it'll kill the cmd line, but not the actual process)
                    try
                    {
                        p.Kill();
                    }
                    catch (InvalidOperationException e) 
                    {
                        controller.PrintImportantError("Process " + p.Id + " failed to exit! Error: " + e.ToString());
                    }
                }
            }
         }
