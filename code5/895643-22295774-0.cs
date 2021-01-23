    static void Main(string[] args)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Public\\Usernames.txt");
            file.WriteLine();
            file.Close();
            int userType = 0;
            System.IO.StreamReader fileUsername =
                new System.IO.StreamReader("C:\\Users\\Public\\Usernames.txt");
            file.Close();
            string retrievedUsername = fileUsername.ReadToEnd();
            file.Close();
            fileUsername.Close();// <--- This line
    
    
    
            Console.WriteLine("Please note that this is a prototype, passwords are not hashed/encrypted ^_^");
            Console.WriteLine("Welcome to the meData service! Ver. 0.01 Beta, made by mechron");
            Console.WriteLine("Please enter your username below or type register to register a new account on this device");
            string loginUsername = Console.ReadLine();
          if (loginUsername == retrievedUsername)
       {
    
              Console.WriteLine("Welcome back user!");
               userType = 1;
       }
          else
          {
              if (loginUsername == "register")
              {
    
                  Console.WriteLine("Choose your username!");
                  string registeredUsername = Console.ReadLine();
                  System.IO.StreamWriter files = new System.IO.StreamWriter("C:\\Users\\Public\\Usernames.txt");
                  file.WriteLine(registeredUsername);
                  file.Close();
              }
              else
              {
                  Console.WriteLine("Error, command not recognized");}
    
          }
    
    
       }
