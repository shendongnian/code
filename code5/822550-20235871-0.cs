    static void DoSomething()
    {
        try
        {
            bool isLoggedIn = service.Login(usernameTextField.Text, passwordTextField.Text);
    
            if(!isLoggedIn)
            {
                new UIAlertView("Login Failed",
                        "Please check your login and try again", null, "OK").Show();
                return;
            }
            
            service.GetImportantData();
            service.SyncUserSpecificData();
            NavigationController.PopToRootViewController(true);
        }
        catch
        {
            new UIAlertView("Login Failed",
                    "Unable to contact server at this time", null, "OK").Show();
        }
        finally
        {
            loadingOverlay.Hide();
        }
    }
