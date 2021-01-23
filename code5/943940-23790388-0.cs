    if (args.Length >= 1)
    {
        if (System.IO.File.Exists(args[0]))
            Application.Run(new DetailsForm(args[0]));
    }
    else 
    {
        Application.Run(new MainForm());
    }
