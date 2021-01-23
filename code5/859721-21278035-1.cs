    public static void print(string s)
    {
        Console.WriteLine("async thread..." + s + DateTime.Now.ToString("T"));
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("async thread after sleep " + DateTime.Now.ToString("T"));
    }
