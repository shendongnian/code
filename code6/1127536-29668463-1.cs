    while(currentState != States.Exit)
    {
       switch (currentState)
       { 
          case Login:
                LoginProcess(new LoginProcessInfo(username, password));
             break;
          case MainMenu:
                MainMenuProcess();
             break;
       }
    }
