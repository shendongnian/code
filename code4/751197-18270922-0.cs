    public static void Main(string[] args)
    {
        MyProcess p = new MyProcess();
        p.StartInfo.FileName = "notepad.exe";
        p.EnableRaisingEvents = true;
        p.Exited += new EventHandler(myProcess_HasExited);
        p.Start();       
    }
    private static void myProcess_HasExited(object sender, System.EventArgs e)
    {
        Console.WriteLine("Process has exited.");
    }
