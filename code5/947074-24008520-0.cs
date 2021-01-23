     public void ProcessData()
     {
         new Thread(() => new RateBar().ShowDialog()).Start(); 
         Worker wk = new Worker();
         wk.WorkProcess += wk_WorkProcess;
         Action handler = new Action(wk.DoWork);
         var result = handler.BeginInvoke(new AsyncCallback(this.AsyncCallback), handler);
     }
