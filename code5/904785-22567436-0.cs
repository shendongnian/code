    static class Program
    {
        static void Main()
        {
            bool isNew = false;
            using (var mutex = new Mutex(false, "MyApplicationName", out isNew))
            {
                if (isNew)
                    Run();
                else
                    RadMessageBox.Show(this, "Application is already running.", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        static void Run()
        {
            // the rest of your program goes here
        }
    }
