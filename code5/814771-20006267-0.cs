    internal sealed class Program
    {
      [DllImport("kernel32.dll")]
      private static extern bool AttachConsole(int dwProcessId);
    
      private const int ATTACH_PARENT_PROCESS = -1;
      [STAThread]
      private static void Main(string[] args)
      {
        if(false)//This would be the run-silent check.
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new MainForm());
        }
        try
        {
          throw new Exception("Always throw, as this tests exception handling.");
        }
        catch(Exception e)
        {
          if(AttachConsole(ATTACH_PARENT_PROCESS))
          {
            //Note, we write to Console.Error, not Console.Out
            //Partly because that's what error is for.
            //Mainly so if our output were being redirected into a file,
            //We'd write to console instead of there.
            //Likewise, if error is redirected to some logger or something
            //That's where we should write.
            Console.Error.WriteLine();//Write blank line because of issue described below
            Console.Error.WriteLine(e.Message);
            Console.Error.WriteLine();//Write blank line because of issue described below
          }
          else
          {
            //Failed to attach - not opened from console, or console closed.
            //do something else.
          }
        }
      }      
    }
