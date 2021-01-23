    newtheard(); // This start new theard with loading form database   
    
        public void newtheard()
            {
                Thread thread = new Thread(new ThreadStart(this.ReadFromMysql);
                thread.IsBackground = true;
                thread.Name = "My Worker.";
                thread.Start();
            }
    
            public void ReadFromMysql()
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        try
                        {
                              // some mysql reader
                        }
                    } 
