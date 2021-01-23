    private void HandleMyThread(object obj)
    {
        Action action = new Action( ()=>
        {
            transformationMatrix.Translate(10, 0);
            circle.RenderTransform = new MatrixTransform(transformationMatrix);
        };
    
        while(isGoing)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, action);
            Thread.Sleep(50);
        }
    }
