    using t = System.Timers;
    
    public void MyMethod()
    {
       t.Timer = new t.Timer(); 
       // this code is equals to 
       // System.Timers.Timer timer = new System.Timers.Timer();
    }
