    public async static Task<string> method(string input, string output, string options, IProgress<int> progress)
    {
        return Task.Factory.StartNew(() => {
            while(something)
            {
                //operations on input and output
               if (progress != null)
               {
                   // use Invoke to marshall update back onto UI thread
                   progressIndicator.Invoke(delegate {
                       progress.Report(percentage);
                   }); 
               }
            } 
        });
    }
