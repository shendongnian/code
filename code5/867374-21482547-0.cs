    private void MeasureTime(Action<int, string> m)
    {
       var sw = new System.Diagnostics.Stopwatch();
       sw.Start();
       m(42, "Hello World");
       sw.Stop();
       ShowTakenTime(sw.ElapsedMilliseconds);
    }
