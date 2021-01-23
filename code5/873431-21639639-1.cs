    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    string initValue = (args != null && args.Length > 0 ? args[0] : string.Empty);
    formMain mainForm = new formMain(initValue);
    Application.Run(mainForm);
