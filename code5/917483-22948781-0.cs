    var thread = new System.Threading.Thread(delegate(){ 
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Start an application context and run one form inside it
        DemoApplicationContext appContext = DemoApplicationContext.getAppContext();
        appContext.RunForm(new Form1());
        Application.Run(appContext);
    });
