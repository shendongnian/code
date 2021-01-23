    void init()
    {
        loadProcess();
    }
    void loadProcess()
    {
        System.Threading.Thread.Sleep(2000);
        System.Diagnostics.Process prc = new System.Diagnostics.Process();
        prc.StartInfo.FileName = "C:\\Windows\\ConsoleApp.exe";
        prc.Exited += new EventHandler(prc_Exited);  // Event Handler when the process is exited. (Mostly not working 4 me)
        prc.Start();
    }
    void prc_Exited(object sender, EventArgs e)
    {
        loadProcess();       
    }
