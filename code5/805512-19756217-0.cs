    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Test1
    {
        public class Class1
        {
            public void test()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.dir.bg/");
    
                request.Method = "GET";
    
                var response = request.GetResponse();
    
                response.Close();
            }
    
            public static void Main()
            {
                CountdownEvent countDown = new CountdownEvent(50);
    
                Stopwatch sw = new Stopwatch();
                sw.Start();
    
                
                for (int i = 0; i < 50; i++)
                {
                    //11646 ms
                    //new Class1().test();
    
                    // 502 ms
                    ThreadPool.QueueUserWorkItem(DoRequest, countDown);
                }
    
                countDown.Wait();
    
                sw.Stop();
    
                MessageBox.Show(sw.ElapsedMilliseconds.ToString());
    
    
            }
    
            private static void DoRequest(Object stateInfo)
            {
                CountdownEvent countDown = (CountdownEvent)stateInfo;
    
                new Class1().test();
    
                countDown.Signal();
            }
        }
    
        
    }
