    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int x = 0; x < Count; x++)
    {
        _temp = MakeKeyToString(1, "Ashley", "MyBrand");
    }
    sw.Stop();
    TimeSpan test = TimeSpan.FromMilliseconds((double)sw.ElapsedMilliseconds);
