        private static int PInvokeWay()
        {
            uint[] processIds = new uint[1024];
            uint bytesCopied;
            uint processCount = 0;
            if (ProcessApi.EnumProcesses(processIds, (uint)processIds.Length * sizeof(uint), out bytesCopied) || bytesCopied == 0)
            {
                processCount = bytesCopied / sizeof(int);
                for (int i = 0; i < processCount; i++)
                {
                    string path;
                    if (Environment.OSVersion.Version.Major >= 6)
                        path = GetExecutablePathAboveVista(processIds[i]);
                    else
                        path = GetExecutablePathXP2003(processIds[i]);
                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        _Processes.Add(new ProcessInfo()
                        {
                            ProcessID = processIds[i],
                            FilePath = path,
                        });
                    }
                }
            }
            return (int)processCount;
        }
        private static string GetExecutablePathAboveVista(uint ProcessId)
        {            
            var buffer = new StringBuilder(1024);
            try
            {
                IntPtr hprocess = ProcessApi.OpenProcess(ProcessApi.PROCESS_QUERY_LIMITED_INFORMATION,
                                              false, ProcessId);
                if (hprocess != IntPtr.Zero)
                {
                    try
                    {
                        int size = buffer.Capacity;
                        if (ProcessApi.QueryFullProcessImageName(hprocess, 0, buffer, out size))
                        {
                            return buffer.ToString();
                        }
                    }
                    finally
                    {
                        ProcessApi.CloseHandle(hprocess);
                    }
                }
            }
            catch { }
            return string.Empty;
        }
        private static string GetExecutablePathXP2003(uint processId)
        {            
            var buffer = new StringBuilder(1024);
            try
            {
                IntPtr process = ProcessApi.OpenProcess(ProcessApi.PROCESS_QUERY_INFORMATION
                    | ProcessApi.PROCESS_VM_READ, false, processId);
                if (process != IntPtr.Zero)
                {
                    try
                    {
                        if (ProcessApi.GetModuleFileNameExW(process, IntPtr.Zero, buffer, buffer.Capacity) != 0)
                        {
                            return buffer.ToString();
                        }
                    }
                    finally
                    {
                        ProcessApi.CloseHandle(process);
                    }
                }
            }
            catch { }
            return string.Empty;
        }
