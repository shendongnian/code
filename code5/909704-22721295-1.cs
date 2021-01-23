    [STAThread]
    public static void Main(string[] args)
    {
        // Do anything you like before running the main window.
        // ...
        // Proceed with usual application flow.
        var app = new MyApplication();
        var win = new MyWindow();
        app.Run(win);
    }
