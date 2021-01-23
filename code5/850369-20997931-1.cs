    private async void CodeOnUiThread()
    {
        //do ui stuff before starting
        await ExecuteProcesses();
        //do ui stuff after completing.
    }
    private async Task ExecuteProcesses() 
    {
        await Task.Factory.StartNew(() =>
        {
            List<string> myStrings = GetMyStrings(); //or whatever you need
            Parallel.ForEach(myStrings,
                new ParallelOptions()
                {
                    MaxDegreeOfParallelism = 4
                }, (s) =>
                {
                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo("myProcess.exe", s);
                    process.Start();
                    process.WaitForExit();
    
                });
        }); 
    }
