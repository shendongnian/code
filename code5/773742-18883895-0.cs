    var sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < 100000; i++)
    {
        var str = "5435%$% r3443_+_+**╥╡←";
        var result = new string(str.Where(o => char.IsDigit(o)).ToArray());
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds); // Takes nearly 107 ms 
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 100000; i++)
    {
        var str = "123213!¤%//)54!!#¤!#%13425";
        var s = Regex.Replace(str, @"\D", "");
    }
    sw.Stop();
    
    Console.WriteLine(sw.ElapsedMilliseconds); //Takes up to 600 ms
    
    
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 100000; i++)
    {
        var str = "5435%$% r3443_+_+**╥╡←";
        var newstr = String.Join("", str.Where(c => Char.IsDigit(c)));
    }
    sw.Stop();
    
    Console.WriteLine(sw.ElapsedMilliseconds); //Takes up to 109 ms
