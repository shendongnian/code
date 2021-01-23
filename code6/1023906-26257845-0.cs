    static void Main()
    {
        Application.ApplicationExit += Application_ApplicationExit;
        ...
    }
    static void Application_ApplicationExit(object sender, EventArgs e)
    {
        MessageBox.Show("Exit!");
    }
