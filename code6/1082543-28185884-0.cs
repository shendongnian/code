    bool isValid = false;
    while (!isValid)
    {
        var cki = Console.ReadKey();
        Console.WriteLine("");
        string character = cki.KeyChar.ToString();
        if (character == "1")
        {
            Console.WriteLine("Please wait...");
            //Name_Updater nu = new Name_Updater();
            //nu.Name_Update();
            isValid = true;
        }
        else if (character == "2")
        {
            Console.WriteLine("Please wait...");
            //WCM_Interaction wi = new WCM_Interaction();
            //wi.Interact_WCM();
            isValid = true;
        }
        else
        {
            Console.WriteLine("Invalid key! Please try again");
        }
    }
