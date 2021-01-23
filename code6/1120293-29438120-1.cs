    public static void GameStart(string[] args) //GameStart Function
    {
        int ToasterHealth = 500; // happens just once, before the loop starts
    
        do {
            Console.WriteLine("Choose a gun to shoot at Toaster... ");
            Console.Write("rocket/sniper/: ");
            // all the stuff to make the gun hurt Toaster here
        } while (ToasterHealth > 0);
        DisplayMessage("You killed Toaster!");
        Console.ReadLine();
    }
