            using System.Threading;
            
            Thread th = new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    Thread.Sleep(100);
                    //do stuff
                }
            }));
