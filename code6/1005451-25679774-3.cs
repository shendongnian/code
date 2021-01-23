    Timer timer = new Timer(TimerCallback, null, 500, 0); 
    
    private void TimerCallback(Object o)
    {
         scan(); 
         scand.WaitOne(); 
         timer.Change(500, 0);
    }
