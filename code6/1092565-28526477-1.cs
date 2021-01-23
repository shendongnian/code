    using System;
    using System.Threading;
        
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                paras myvalues = new paras();
    
                myvalues.para1 = 10;
                myvalues.para2 = 20;
        
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod),myvalues);
    
    
                Console.ReadKey();
            }
    
            static void ThreadMethod(object state)
            {
                paras vals =(paras) state;
    
                Console.WriteLine(vals.para1);
                Console.WriteLine(vals.para2);
                
            }
    
        }
    
        struct paras
        {
            int Para1;
    
            public int para1
            {
                get { return Para1; }
                set { Para1 = value; }
            }
    
            int Para2;
    
            public int para2
            {
                get { return Para2; }
                set { Para2 = value; }
            }
        }
    }
