        void DoSomething()
        {
            Thread.Sleep(100);
        }
        void Test()
        {
            DateTime dt = DateTime.Now;
            for (int i=0; i<500; i++)        
            {
                Thread t = new Thread(() => DoSomething());
                t.IsBackground = true;
                t.Start();
                Thread.Sleep(5);
            }
            MessageBox.Show(DateTime.Now.Subtract(dt).TotalSeconds.ToString() );
         }
