     public void OPTIMIZATION_ITERATION()
    {
           Thread WORK = new Thread(new ThreadStart(WORKVOID));
                WORK.Name = "T1";
                WORK.Start();
           Thread WORK2 = new Thread(new ThreadStart(WORKVOID2));
               WORK2.Name = "T2";
                WORK2.Start();
    }
            public void WORKVOID()
            {
                for (ALPHA = 0.001; ALPHA <= 0.5; ALPHA += 0.001)
                STARTWORK(1);
            }
            public void WORKVOID2()
            {
                for (ALPHA = 0.5; ALPHA <= 1; ALPHA += 0.001)
                STARTWORK(2);
            }
