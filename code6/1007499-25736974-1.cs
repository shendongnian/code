    private static void Main()
    {
        var container = BuildUnityContainer();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
