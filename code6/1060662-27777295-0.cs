        internal class Program
        {
            private static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    Execute(args[0]);
                }
            }
    
            private static void Execute(string chmFile)
            {
                const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
    
                ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\hh.exe");
                info.Arguments = chmFile;
                info.UseShellExecute = true;
                info.Verb = "runas";
                try
                {
                    Process.Start(info);
                }
                catch (Win32Exception ex)
                {
                    if (ex.NativeErrorCode == ERROR_CANCELLED)
                        Console.WriteLine("Why you no select Yes?");
                    else
                        throw;
                }
            }
        }
