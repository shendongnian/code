    [STAThread]
    static void Main()
    {
        //instanciate MyController for further use
        controller = new MyController();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormMain(controller));
    }
    private static MyController controller;
