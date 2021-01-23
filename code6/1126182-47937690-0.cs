      public ParallelDemo()
        {
            Parallel.Invoke(() => 
                            {
                                PrintCount(-10000, 0);
                            },
                            ()=>{
                                PrintCount(1, 10000);
                            }
                            );
        }
        public void PrintCount(int LowLimit , int UpperLimit)
        {
            for (int i = LowLimit; i <=UpperLimit; i++)
            {
                Console.WriteLine("> {0}" , i);
            }
        }
