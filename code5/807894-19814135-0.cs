    static void Main()
    {
        DateTime now = DateTime.Now;
        DateTime tomorrow = now.AddDays(1);
        if (DateTime.Compare(now, tomorrow) == 0)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
