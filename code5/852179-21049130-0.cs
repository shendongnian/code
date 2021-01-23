    public static void Main()
    {
        //Show splash form (which checks for updates)
        FormSplash splash = new FormSplash();
        splash.ShowDialog();//will wait until splash closed
    
        //check if first run and show if needed
        if(IsFirstRun())
        {
            FormWizard wizard = new FormWizard();
            wizard.ShowDialog();//will wait until wizard is closed
        }
    
        //Finally, run your application as normal
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new frm_Main());
    }
