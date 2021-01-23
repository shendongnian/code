    bool isGoing = false;
    private void MouseMouseDown(object sender, MouseButtonEventArgs e)
    {
        isGoing = true;
        new Thread(new ThreadStart(() => { while (isGoing) { Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() => { if (isGoing)
        {
            //Whatever you want to happen continuously ie. move your image
        }}));}})).Start();
    }
    private void MouseUp(object sender, MouseButtonEventArgs e)
    {
        isGoing = false;
    }
