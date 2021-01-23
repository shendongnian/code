    var sw = new Stopwatch();
    var str = "5435%$% r3443_+_+**╥╡←";
    sw.Start();
    for (int i = 0; i < 100000; i++)
    {       
        var result = new string(str.Where(o => char.IsDigit(o)).ToArray());
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds); // Takes nearly 107 ms 
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 100000; i++)
    {
        var s = Regex.Replace(str, @"\D", "");
    }
    sw.Stop();
    
    Console.WriteLine(sw.ElapsedMilliseconds); //Takes up to 600 ms
    
    
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 100000; i++)
    {
        var newstr = String.Join("", str.Where(c => Char.IsDigit(c)));
    }
    sw.Stop();
    
    Console.WriteLine(sw.ElapsedMilliseconds); //Takes up to 109 ms
