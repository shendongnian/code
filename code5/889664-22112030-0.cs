    System.Diagnostics.Stopwatch stp = new System.Diagnostics.Stopwatch();
    stp.Start();
    StringBuilder str = new StringBuilder()
    str.Append("12345");  
    Console.WriteLine(stp.ElapsedTicks);
