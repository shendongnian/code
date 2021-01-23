    static void Main(string[] args)
    {
        System.Timers.Timer timer = new System.Timers.Timer(5000);
    
        timer.Elapsed += (obj, ev) =>
        {
            System.IO.File.AppendAllLines(@"D:\test.txt", new string[] { DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") }, Encoding.UTF8);
            System.Threading.Thread.Sleep(3000);
    
            System.IO.File.AppendAllLines(@"D:\test.txt", new string[] { DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " - New" }, Encoding.UTF8);
            //if you want to be sure it will execute, wrap the code above with try... catch
            timer.Start();
        };
        timer.AutoReset = false;
        timer.Start();
    
        Console.ReadLine();
    }
