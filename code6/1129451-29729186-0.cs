    Process p= new Process();
    p.StartInfo.FileName = "demo.exe";
    p.StartInfo.Arguments = "param1 param2";
    p.Start();
    p.WaitForExit();
    or
    
    Process.Start("demo.exe", "param1 param2");
    
    in demo.exe
    
    static void Main (string [] args)
    {
      Console.WriteLine(args[0]);
      Console.WriteLine(args[1]);
    }
