    private static bool MAXIMIZED = false;
    private void maximizeButton_Click(object sender, System.EventArgs e)
    {
        if(MAXIMIZED)
        {
            WindowState = FormWindowState.Normal;
            MAXIMIZED = false;
        }
        else
        {
            WindowState = FormWindowState.Maximized;
            MAXIMIZED = true;
        }
    }
