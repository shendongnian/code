    private static List<Process> processes = new List<Process>();
	static void Main(string[] args)
	{
		int PID = StoreProcess (yourProcess);
        KillProcess(PID);    
	}
	/// <summary>
	/// Stores the process in a list
	/// </summary>
	/// <returns>The PID</returns>
	/// <param name="prc">The process to be stored</param>
	public static int StoreProcess(Process prc)
	{
		int PID = prc.Id;
		processes.Add (prc);
		return PID;
	}
	/// <summary>
	/// Kills a process
	/// </summary>
	/// <param name="PID">The PID of the process to be killed.</param>
	public static void KillProcess(int PID)
	{
		for (int i = 0; i <= processes.Count; i++) {
			if (processes [i].Id == PID) {
				processes [i].Kill ();
				while (!processes [i].HasExited) {
					// Wait for it to exit
				}
				processes [i] = null;
			}
		}
		throw new Exception ("Process not found!");
	}
