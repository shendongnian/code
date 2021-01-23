    foreach (Type type in dll.GetExportedTypes())
    {                
        if (type.Name.Equals("MainWindow"))
        {                   
            dynamic n = null;
            n = Activator.CreateInstance(type);
            n.InitializeComponent();
            System.Windows.Application apprun = new System.Windows.Application();
            apprun.Run(n);
            break;
        }
    }
