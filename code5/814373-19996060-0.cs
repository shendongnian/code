    public void myFunction()
    {
    int startCount = Environment.TickCount;
    ask_state();
    check_state();
    
    while (true)
    {
    if (Environment.TickCount - startCount >= 20000) //two seconds 
    {
    break;
    }
    Application.DoEvents();
    }
    }
    
    //Now you have an organized function that makes the task you want just call it every
    // time interval, again you can use a timer to do that for you
    
    private void timer_Tick(object sender, EventArgs e)
    {
                myFunction();
    }
