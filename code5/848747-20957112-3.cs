    class Engine
    {
        public int ComplexMethod(int arg, IProgress<double> progress)
        {
            int result = 0;
    
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    // some complex and time-consuming computations
                }
    
                progress.Report(i / 100000);
            }
    
            return result; 
        }
    }
    ...
    var progress = new Progress<double>(p => ShowProgress(p));
    var result = await Task.Run(() => engine.ComplexMethod(arg, progress));
    ShowResult(result);
