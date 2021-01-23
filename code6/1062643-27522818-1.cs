    public void DoWork(IProgress<Tuple<int,string> progress)
    {
        for (int i=0;i++;i<1000)
        {
             if (i%10==0)
             {
                 progress.Report(Tuple.Create(i/10,String.Format("Now at {0}",i);
             }
        }
    }
        
