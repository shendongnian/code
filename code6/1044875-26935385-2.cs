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
		int PID = prc.Id; // Get the process PID and store it in an int called PID
		processes.Add (prc); // Add this to our list of processes to be kept track of
		return PID; // Return the PID so that the process can be killed/changed at a later time
	}
	/// <summary>
	/// Kills a process
	/// </summary>
	/// <param name="PID">The PID of the process to be killed.</param>
	public static void KillProcess(int PID)
	{
        // Search through the countless processes we have and try and find our process
		for (int i = 0; i <= processes.Count; i++) {
            if (processes [i] == null)
            {
                continue; // This segment of code prevents NullPointerExceptions by checking if the process is null before doing anything with it
            }
			if (processes [i].Id == PID) { // Is this our process?
				processes [i].Kill (); // It is! Lets kill it
				while (!processes [i].HasExited) { } // Wait until the process exits
				processes [i] = null; // Mark this process to be skipped the next time around
			}
		}
        // Couldn't find our process!!!
		throw new Exception ("Process not found!");
	}
