    private static Thread w1;
    private static Thread w2;
    
     public void klawisze(object sender, KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == 21) //CTRL + SHIFT + U
                {   
                    if (w2 != null)
                    {    
                           Stop();
                           w2.Join();
                           while (w2.IsAlive)
                           {
                                  Thread.Sleep(100);
                           }
                    }
                    stopIt = false;
                    w1 = new Thread(new ThreadStart(pw));
                    w1.Start();
                }
                if (e.KeyChar == 9) //CTRL + SHIFT + I
                {   //2
                    if (w1 != null)
                    { 
                           Stop();
                           w1.Join();
                           while (w1.IsAlive)
                           {
                                  Thread.Sleep(100);
                           }
                           stopIt = false;
                    }
                    w2 = new Thread(new ThreadStart(dw));
                    w2.Start();
                }
            }
