    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Application.SlideShowBegin += Application_SlideShowBegin;   
    }
    private void Application_SlideShowBegin(PowerPoint.SlideShowWindow Wn)
    {
        // your implementation
    }
