     private void GetUserData()
            {
               // System.Diagnostics.Debug.WriteLine("Grabbing Data");
    
                if (IsolatedStorageSettings.ApplicationSettings.Contains("userLoggedIn"))
                {
                    string isLoggedIn = IsolatedStorageSettings.ApplicationSettings["userLoggedIn"] as string;
                    if (isLoggedIn.EndsWith("rue"))
                        isLoggedOn = true;
                    else
                        isLoggedOn = false;
                //    System.Diagnostics.Debug.WriteLine("log in data " + isLoggedIn + " " + isLoggedOn);
                }
                else
                {
                    myUserSettings.Add("userLoggedIn", "false");
                    isLoggedOn = false;
                }
    
    
    
                if (IsolatedStorageSettings.ApplicationSettings.Contains("fullAccess"))
                {
                    string hasFullAccess = IsolatedStorageSettings.ApplicationSettings["fullAccess"] as string;
                    if (hasFullAccess.EndsWith("rue"))
                        fullAccess = true;
                    else
                        fullAccess = false;
                }
                else
                {
                    myUserSettings.Add("fullAccess", "false");
                    fullAccess = false;
                }
    
    
                if (IsolatedStorageSettings.ApplicationSettings.Contains("username"))
                {
                    username = IsolatedStorageSettings.ApplicationSettings["username"] as string;
                }
                else
                {
                    myUserSettings.Add("username", "");
                    username = "me";
                }
    
                if (IsolatedStorageSettings.ApplicationSettings.Contains("password"))
                {
                    password = IsolatedStorageSettings.ApplicationSettings["password"] as string;
                }
                else
                {
                    myUserSettings.Add("password", "");
                    password = "v";
                }
                myUserSettings.Save();
    
    
            }
