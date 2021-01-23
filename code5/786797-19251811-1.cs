    private bool running;
    private bool restart;
    
    private void DoWork(object item)
    {
        running = true;    
        TSM.ModelObjectEnumerator myEnum = null;
        myEnum = new TSM.UI.ModelObjectSelector().GetSelectedObjects();
    
        while (myEnum.MoveNext() && !restart)
        {       
            //do your stuff
            if (myEnum.Current != null) {....}
        }
        if(restart)
        {
            restart = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));
        }
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (running)
            restart = true;
        else            
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));            
    }
