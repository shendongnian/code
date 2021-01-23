    public async Task DoStuffAsync()
    {
       try
       {
           var success=await service.Login(usernameTextField.Text, passwordTextField.Text);
           if(success)
           {
               var data=await service.GetImportantData();
               await service.SyncUserSpecificData();
               NavigationController.PopToRootViewController(true);
           }
       }
       catch(WebException exc)
       {
           new UIAlertView("Login Failed", "Unable to contact server at this time", null, "OK").Show();
       }
       catch(Exception exc)
       {
           new UIAlertView("Login Failed", ex.Message, null, "OK").Show();
       }
            
       loadingOverlay.Hide();
    }
        
