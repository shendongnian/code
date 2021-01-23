	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
	[DllImport("kernel32.dll")]
	public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
	const int PROCESS_WM_READ = 0x0010;
	static void Main()
	{
		try
		{
			using (var sw = new StreamWriter("O:\\out.txt"))
			{
				Console.SetOut(sw);
				while (true)
				{
					Act();
				}
			}
		}
		catch (Exception e)
		{
			Debug.WriteLine(e.Message);
		}
	}
