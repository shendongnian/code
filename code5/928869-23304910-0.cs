    //...
    Window win = new Window();
    while (true)
    {
        var key = Console.ReadKey().Key;
        // press 1 to open
        if (key == ConsoleKey.D1)
        {
            //uncomment following line if you want a fresh window instance everytime
            //win = new Window();
            DispatchToApp(() => win.Show());
        }
        // Press 2 to exit
        if (key == ConsoleKey.D2)
        {
            DispatchToApp(() => win.Close());
        }
    }
