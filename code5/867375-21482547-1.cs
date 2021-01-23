    private void MeasureTime(Func<int, string, string> m)
    {
       var sw = new System.Diagnostics.Stopwatch();
       sw.Start();
       var result = m(42, "Hello World");
       sw.Stop();
       ShowTakenTime(sw.ElapsedMilliseconds);
    }
