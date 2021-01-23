    var g = CreateGraphics();
    
    using (var brush = new SolidBrush(Color.Red))
    {
        Point point = new Point(0,0);
        Rectangle sourceRect = new Rectangle(100,100,100,100);
    
        var invoker = new MethodInvoker(() =>
        {
            // The following line will filling up the memory.
            g.CopyFromScreen(new Point(0,0), sourceRect.Location, sourceRect.Size);
        });
        do
        {
            BeginInvoke(invoker);
        } while (!mre.WaitOne(1));
    }
