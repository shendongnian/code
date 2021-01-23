    void WaitProc(object state, bool timedOut)
    {
        if (timedOut) 
    	{
             //periodically fire every 1000ms
             //update the lable, remember this is a background thread 
             //so you have to use BeginInvoke
             this.BeginInvoke(new InvokeDelegate(()=>{lblVoiceDuration.Text = wmpPlayer.Ctlcontrols.currentPositionString;}));
        }
        else
        {
            //Caused by signal of WaitHandle(are.Set();)
            //don't forget to unregister rwh           
            //so this callback will not be fired any more
            rwh.Unregister();
        }
    }
