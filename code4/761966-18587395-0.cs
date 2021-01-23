      Public WFPrintCustomActivity()
                {
                    InitializeComponent();
        
                    settings = new Settings();
                    //Logs("STARTED");
        
        
                    pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                }
