    static void Main(string[] args)
    {
        System.Threading.Timer timer = new System.Threading.Timer(Callback, null, 0, 1 * 1000);
        Console.ReadLine();
    }
    static void Callback(object state)
    {
        Console.WriteLine(DateTime.Now.ToString("hh:MM:ss:ffff"));
    }
