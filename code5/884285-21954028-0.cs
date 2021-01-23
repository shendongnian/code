    private bool AlertMe()
    {
        bool isCompleted = false;
        System.Diagnostics.Process.Start(“CMD.exe”,@”/C cd\ & mySecondCommandHere“);
        isCompleted = true;
        System.Media.SystemSounds.Beep.Play();
        return isCompleted;
    }
