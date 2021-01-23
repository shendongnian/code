    public async Task<string> method(string input, string output, string options, IProgress<int> progress)
    {
        return Task.Factory.StartNew(() => {
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
