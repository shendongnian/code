    string loginUsername = Console.ReadLine();
    string readText = File.ReadAllText(path);
    if(readText==loginUsername)
    {
       Console.WriteLine("Welcome back user!");
    }else if(loginUsername == "register")
    {
    
       Console.WriteLine("Choose your username!");
       string registeredUsername = Console.ReadLine();
       File.WriteAllText(path,registeredUsername);
    }
