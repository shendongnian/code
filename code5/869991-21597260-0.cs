    try
     {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains("email_id"))
                    {
                        IsolatedStorageSettings.ApplicationSettings["email_id"] = emailid;
                        IsolatedStorageSettings.ApplicationSettings["password"] = password;
                        IsolatedStorageSettings.ApplicationSettings.Save();
                    }
                    else
                    {
                        IsolatedStorageSettings.ApplicationSettings.Add("email_id", emailid);
                        IsolatedStorageSettings.ApplicationSettings.Add("password", password);
                        IsolatedStorageSettings.ApplicationSettings.Save();
                    }
                }
                catch (Exception ex)
                {
                  
                    Console.WriteLine(ex.InnerException);
                }
