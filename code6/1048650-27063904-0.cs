    static class Program
    {
        static void Main()
        {
            if (RunningAsWindowsServiceCondition)
            {
                // run aaplication in windows service mode
            }
            else
            {
                // run as WinForms application
                var thread = new Thread(RunAsWinForms);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }
        private static void RunAsWinForms()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
