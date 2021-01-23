    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace CheckIfRunningFromPowerShell
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			if (PowerShellUtils.IsCurrentProcessRunningFromPowerShellIse())
    			{
    				Console.WriteLine("PowerShell, yay!");
    			}
    			else
    			{
    				Console.WriteLine("NOPE :(");
    			}
    		}
    	}
    
    	public class PowerShellUtils
    	{
    		public static bool IsCurrentProcessRunningFromPowerShellIse()
    		{
    			var processList = new uint[1];
    			var count = GetConsoleProcessList(processList, 1);
    			if (count <= 0)
    			{
    				return false;
    			}
    
    			processList = new uint[count];
    			count = GetConsoleProcessList(processList, (uint)processList.Length);
    			for (var pid = 0; pid < count; pid++)
    			{
    				var buffer = new StringBuilder(260);
    				var dwSize = (uint) buffer.Capacity;
    
    				var process = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, false, (int) processList[pid]);
    				QueryFullProcessImageName(process, 0, buffer, ref dwSize);
    
    				var exeFileName = buffer.ToString(0, (int) dwSize);
    
    				// Name of EXE is PowerShell_ISE.exe or powershell.exe
    				if (exeFileName.IndexOf("PowerShell_ISE.exe", StringComparison.OrdinalIgnoreCase) != -1 ||
    				    exeFileName.IndexOf("powershell.exe", StringComparison.OrdinalIgnoreCase) != -1)
    				{
    					return true;
    				}
    			}
    
    			return false;
    		}
    
    		[DllImport("kernel32.dll", ExactSpelling=true, EntryPoint="QueryFullProcessImageNameW", CharSet = CharSet.Unicode)]
    		internal static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, StringBuilder lpExeName, ref uint lpdwSize);
    
    		[DllImport("kernel32.dll", ExactSpelling=true)]
    		internal static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    
    		[DllImport("kernel32.dll", SetLastError = true)]
    		static extern uint GetConsoleProcessList(uint[] processList, uint processCount);
    
    		// ReSharper disable InconsistentNaming
    		internal const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
    		// ReSharper restore InconsistentNaming
    	}
    }
