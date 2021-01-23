    var waitHandles = new List<EventWaitHandle>();
    for (int index = 0; index < tests.Count; index/=3)
    {
        var waitHandle = new ManualResetEvent(false);
        waitHandles.Add(waitHandle);
        System.Threading.Thread t =
            new System.Threading.Thread(
                () =>
                {
                    SomeFunction(tests.GetRange(start, 3));
                    waitHandle.Set();
                });
        t.Start();
    }
    WaitHandle.WaitAll(waitHandles.ToArray());
    MessageBox.Show("Done!");
