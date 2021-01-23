    private bool running;
    private bool restart;
    
    private void DoWork(object item)
    {
        running = true;    
        TSM.ModelObjectEnumerator myEnum = null;
        myEnum = new TSM.UI.ModelObjectSelector().GetSelectedObjects();    
        while (myEnum.MoveNext())
        {
            if (!restart)
            {
                //do your stuff
                if (myEnum.Current != null)
                {....}
            }
            else
            {
                //exit and restart
                restart = false;
                ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));
                break;
            }
        }            
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (running)
            restart = true;
        else            
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));            
    }
