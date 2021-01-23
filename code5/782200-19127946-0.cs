    Action action;
    public void Main()
    {
    action = new Action(delegate()
    {
        if (images.Count > 0)
        {
            bmp = images[0];
            images.RemoveAt(0);
        }
    });
    Thread thread = new Thread(SaveBitmap());
    thread.Start();
    thread.Priority =  ThreadPriority.Highest
    }
    public void SaveBitmap()
    {
        Dispatcher.Invoke(action);
    if (bmp != null)
    {
        bmp.Save("frames\\" + framesImagesIndex++ + ".png", ImageFormat.Png);
        bmp.Dispose();
        bmp = null;
    }
    }
