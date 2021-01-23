    TimerClockThread = new Thread( new ParameterizedThreadStart(Empuje));
    private void Empuje(object objeto)
    {
       Thread.Sleep(2000); 
       Dispatcher.BeginInvoke(new Action(() => {
           MessageBox.Show("This should not freeze the window");
       }));
       //........ Do stuff.....
    }
