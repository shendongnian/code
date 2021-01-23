    public class ProcessManager
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, uint windowStyle);
        
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        ProcessManager()
        {
          string processName = /* Your process name here */
          SearchProcessAndModifyState(processName)
        }
    
        void SearchProcessAndModifyState(string targetProcessName)
        {
            Process specifiedProcess = null;
          	Process[] processes = Process.GetProcesses();
           	for (int i = 0; i < processes.Length; i++)
           	{
           		Process process = processes[i];
           		if (process.ProcessName == targetProcessName)
           		{
           			specifiedProcess = process;
           			break;
           		}
           	}
           	if (specifiedProcess != null)
           	{
           	  ProcessManager.ShowWindow(specifiedProcess.MainWindowHandle, 1u);
        	  ProcessManager.SetWindowPos(specifiedProcess.MainWindowHandle, new IntPtr(-1), 0, 0, 0, 0, 3u);
            }
        }
    }
