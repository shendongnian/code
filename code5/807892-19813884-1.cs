    static void Main()
    {
        var someObject = SomeFactory.Fetch(someCriteria);
        if (someObject.SomeValue == false)
            Application.Exit();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
