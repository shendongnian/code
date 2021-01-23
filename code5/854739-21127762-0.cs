	static void Main(string[] args)
	{
		// Get the 'notepad' process.
		var notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
		if (notepad == null)
			throw new Exception("Notepad is not running.");
		// Find its window.
		IntPtr window = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero,
			"Edit", null);
		// Send some string.
		SendMessage(window, WM_SETTEXT, 0, "Hello world!");
	}
