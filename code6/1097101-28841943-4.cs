    public Form1()
    {
        InitializeComponent();
        try
        {
            this.axFoxitPDFSDK1.OpenFile(@"C:\foxit\FoxitPDFActiveX51_Manual.pdf", "");
            
           this.axFoxitPDFSDK1.PrintWithDialog();
        }
        catch (System.Exception exc)
        {
            Debug.WriteLine(exc.StackTrace);
            Debug.WriteLine(exc.Message);
            if (exc.InnerException != null)
            {
                Debug.WriteLine(exc.InnerException.Message);
            }
        }
    }
