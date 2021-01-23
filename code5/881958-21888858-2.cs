    public void SlowPrint(string FileName)
    {
        var iterator = File.ReadLines(FileName).GetEnumerator();
        System.Threading.Timer timer = null;
        timer = new System.Threading.Timer(o =>
        {
            if (iterator.MoveNext())
                Console.WriteLine(iterator.Current);
            else
            {
                iterator.Dispose();
                timer.Dispose();
            }
        }, null, 700, Timeout.Infinite);
    }
