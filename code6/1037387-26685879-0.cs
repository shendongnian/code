    private Process previousProcess = null;
    public CreateImage()
    {
        //Here put png creation as you already have
        //Now attempt to open it if the previous instance has closed
        if(this.previousProcess == null || this.previousProcess.HasExited)
        {
            //Either there was no previous image opened or it was already closed, go ahead and open it
            if(this.previousProcess != null) this.previousProcess.Dispose();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = @"Labyrinth.png";
            myProcess.Start();
            //Cache the newly launched process to check for it afterwards
            this.previousProcess = myProcess;
        }
    }
