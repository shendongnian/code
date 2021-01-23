    using System.Diagnostics;
    void myprocess()
    {
        Process myproc = Process.Start(...);
        Process notepad =  Process.Start(NOTEPAD.EXE)
        //do whatever
        notepad.Kill();
    }
