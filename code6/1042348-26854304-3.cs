    //make the progress bar indeterminate (we don't know how long we will be "busy")
    myProgBar.IsIndeterminate = true;
    
    //Create a thread that will do our loop work.
    Thread t = new Thread(new ThreadStart(() => 
    {
    //do our looping;
    while (true) {//do work}
    //when loop is done, we want to hide the progress bar
    //but we created it on a different thread, so we must use its dispatcher to do
    //the work from this thread
    myProgBar.Dispatcher.Invoke(new Action(() => { myProgBar.Visibility = Visibility.Hidden; }));
    }));
    
    //make the bar visible, letting users know we are about to be "busy"
    myProgBar.Visibility = Visibility.Visible;
    //start doing our work
    t.Start();
    
   
