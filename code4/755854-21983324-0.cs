    [DllImport("kernel32.dll")]
    static extern bool AttachConsole(int dwProcessId);
    private const int ATTACH_PARENT_PROCESS = -1;
    [STAThread]
    static void Main(string[] args)
    {
      // Enable visual elements just like always
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
    
      // Attach to the parent process via AttachConsole SDK call
      AttachConsole(ATTACH_PARENT_PROCESS);   // <-- important point here
      Console.WriteLine("This is from the main program");
    
      Application.Run(new Form1());
    }
    
