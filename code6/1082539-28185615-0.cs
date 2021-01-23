                character = cki.KeyChar.ToString();
                if (character == "1")
                {
                    Console.WriteLine("Please wait...");
                    Name_Updater nu = new Name_Updater();
                    nu.Name_Update();
                    flag=false;
                } 
                else if (character == "2")
                {
                    Console.WriteLine("Please wait...");
                    WCM_Interaction wi = new WCM_Interaction();
                    wi.Interact_WCM();
                    flag=false;
                }
                else
                {
                    Console.WriteLine("Invalid key! Please try again");
                }
            }while(flag)
            
