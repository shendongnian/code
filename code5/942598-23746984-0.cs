     static void OpenMicrosoftWord(string f)
    {
	ProcessStartInfo startInfo = new ProcessStartInfo();
	startInfo.FileName = "WINWORD.EXE";
	startInfo.Arguments = f;
	Process.Start(startInfo);
    }
