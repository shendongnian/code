        public static void AttachVisualStudioToProcess(Process visualStudioProcess, Process applicationProcess)
        {
            _DTE visualStudioInstance;
            if (TryGetVsInstance(visualStudioProcess.Id, out visualStudioInstance))
            {
                EnvDTE100.Debugger5 dbg5 = (EnvDTE100.Debugger5)visualStudioInstance.Debugger;
                EnvDTE80.Transport trans = dbg5.Transports.Item("Default");
                EnvDTE80.Engine dbgeng;
                dbgeng = trans.Engines.Item("Managed (v4.5, v4.0)");
                var proc2 = (EnvDTE80.Process2)dbg5.GetProcesses(trans, "WIN-86CEJEGQCPD").Item("iisexpress.exe");
                proc2.Attach2(dbgeng);
               
            }
        }
