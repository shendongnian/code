    cki = Console.ReadKey();
    string character = cki.KeyChar.ToString();
    while (true) // infinite loop
    {
            if (character == "1")
            {
                Console.WriteLine("Please wait...");
                Name_Updater nu = new Name_Updater();
                nu.Name_Update();
                break; // break from loop if you read "1"
            }
            if (character == "2")
            {
                Console.WriteLine("Please wait...");
                WCM_Interaction wi = new WCM_Interaction();
                wi.Interact_WCM();
                break;  // break from loop if you read "2"
            }
            // repeat loop if invalid entery
            Console.WriteLine("Invalid key! Please try again");
            cki = Console.ReadKey();
            character = cki.KeyChar.ToString();
    }
