    foreach (var app in appList)
                {
                    foreach (string li in allApps) 
                    {
                        bool istrueapp = app.AppName.Equals(li);
                        if (istrueapp)
                        {
                            Appname2.AddLast(app.AppName);
                        }
                    }
                }
