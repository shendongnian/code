    var myProcess =  Process.GetCurrentProcess();
    myProcess.Exited += new EventHandler(myProcess_Exited);
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
         //not sure if there is a way to prevent the process from exiting here.
    }
