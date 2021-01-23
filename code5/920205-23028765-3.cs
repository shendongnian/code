    CancellationTokenSource _tokenSource;
            private IEnumerable<string> _source;
            int _parallelThreads = 10;
            private Tuple<int,String> Currenct_Item;
    
            public void doWork()
            {
                _tokenSource = new CancellationTokenSource();
                var token = _tokenSource.Token;
    
                IEnumerable<Tuple<int,string>> _indexed_source = WithIndecies(_source);
    
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Parallel.ForEach(_indexed_source,
                            new ParallelOptions
                            {
                                MaxDegreeOfParallelism = _parallelThreads //limit number of parallel threads 
                            },
                            file =>
                            {
                                if (token.IsCancellationRequested)
                                    return;
                                Currenct_Item = file; // Save CurrentFile and Access it from anywhere else to see current file being processed
    
                                // file.Item2 is the String so use it in the 'do work'
                                //do work...
                            });
                    }
                    catch (Exception)
                    { }
    
                }, _tokenSource.Token).ContinueWith(
                        t =>
                        {
                            //finish...
                        }
                    , TaskScheduler.FromCurrentSynchronizationContext() //to ContinueWith (update UI) from UI thread
                    );
            }
    
            private IEnumerable<Tuple<int,string>> WithIndecies(IEnumerable<string> _source)
            {
                int i =1;
                return _source.Select(x => Tuple.Create(i++, x));
            }
