    class Program
        {
            static void Main(string[] args)
            {
                for (int i = 0; i < 10; i++)
                    //ParallelArray();
                    SingleFor();
            }
    
            const int _meg = 1024 * 1024;
            const int _len = 1024 * _meg;
    
             static void ParallelArray()
            {
                int[] stuff = new int[_meg];
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();           
                s.Start();
                Parallel.For(0,
                    _len,
                    i =>
                    {
                        stuff[i % _meg] = i;
                    }
                    );
                s.Stop();          
    
             System.Console.WriteLine( s.ElapsedMilliseconds.ToString());
    
            }
    
             static void SingleFor()
             {
                 int[] stuff = new int[_meg];
                 System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
               
                 s.Start();
    
                 for (int i = 0; i < _len; i++){
                         stuff[i % _meg] = i;
                     }
                     
                 s.Stop();            
    
                 System.Console.WriteLine(s.ElapsedMilliseconds.ToString());
             }
        }
