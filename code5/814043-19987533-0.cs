      if (ABCFile > 0)
      {
        var me = new MainForm(); // instantiate the form
        me.NoGui(ABCFile); // call the alternate entry point
        Environment.Exit(0);
      }
      else
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
      }
