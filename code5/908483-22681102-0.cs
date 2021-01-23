    private void Application_Launching(object sender, LaunchingEventArgs e)
            {
                IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
                //Save first launch date
                if (!userSettings.Contains("Date"))
                {
                    userSettings.Add("Date", DateTime.Now.Date);
                }
                else
                {
                    DateTime saveDate = Convert.ToDateTime(userSettings["Datetime"]);
                    double days = (DateTime.Now.Date - saveDate).TotalDays;
                    if (days > 30)
                    {
                        //Do you work 
                        //remove userSettings for reset settings 
                        userSettings.Remove("Date");
                    }
                }
            userSettings.Save();
        }
