    static void DoSomething()
    {
        service.Login(usernameTextField.Text, passwordTextField.Text)
            .ContinueWith(task =>
            {
                bool isLoggedIn = task.Result;
                
                if(!isLoggedIn)
                {
                    new UIAlertView("Login Failed",
                            "Please check your login and try again", null, "OK").Show();
                    // this is just a dummy task to return without error.
                    return Task.FromResult(false);
                }
                
                return service.GetImportantData()
                    .ContinueWith(task2 =>
                    {
                        // do something with task2
                        task2.Wait(); // just forcing exceptions to be thrown.
                        
                        return service.SyncUserSpecificData();
                    }).Unwrap()
                    .ContinueWith(task2 =>
                    {
                        // task2 is the result from SyncUserSpecificData().
                        task2.Wait(); // again just forcing exceptions to be thrown.
                        NavigationController.PopToRootViewController(true);
                    });
            }).Unwrap()
            .ContinueWith(task =>
            {
                new UIAlertView("Login Failed",
                        "Unable to contact server at this time", null, "OK").Show();
            }, TaskContinuationOptions.OnlyOnFaulted)
            .ContinueWith(task =>
            {
                loadingOverlay.Hide();
            });
    }
