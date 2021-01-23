    // allocate buffer at class scope
    private byte[] _theBuffer = new byte[1024*1024];
    public void PerfTestMeasureGetBytes()
    {
        // ...
        for (...)
        {
            var sw = Stopwatch.StartNew();
            var numberOfBytes = Encoding.UTF8.GetBytes(smallText, 0, smallText.Length, _theBuffer, 0);
            sw.Stop();
            // ...
        }
