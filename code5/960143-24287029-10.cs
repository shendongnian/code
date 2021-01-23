    public Task method(string input, string output, string options, IProgress<int> progress)
    {
        return Task.Run(() => {
            while(something)
            {
                //operations on input and output
               if (progress != null)
               {
                   progress.Report(percentage);
               }
            }
        });
    }
