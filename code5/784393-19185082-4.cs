    void Main()
    {
        string str = "RamaSubbaReddyabcdaacacakkkoooahgafffgahgghsa";
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for(int i = 0; i < 10000000; i++)
        {
            int count = CountChar(str, 'a');
         }   
        sw.Stop();
        Console.WriteLine("Using IndexOf:" + sw.ElapsedMilliseconds.ToString());  
        sw.Reset();
        sw.Start();
        for(int i = 0; i < 10000000; i++)
        {
            int countA = str.Count(r => r == 'a');
        }
        sw.Stop();
        Console.WriteLine("Using Count:" + sw.ElapsedMilliseconds.ToString());
    }
