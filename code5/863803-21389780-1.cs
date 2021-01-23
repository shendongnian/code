    protected async void Page_Load(object sender, EventArgs e)
    {
        string email = "test@test.com";
        bool[] success = await Task.WhenAll(MyAppStorage.StoreInSqlAsync(email),
            MyAppStorage.StoreInOtherDatabaseAsync(email));
        if (success[0] && success[1])
        {
            labelOutputMessage.Text = "Successfully stored the email.";
        }
        else
        {
            labelOutputMessage.Text = "We couldn't store the email, sorry!";
        }
    }
