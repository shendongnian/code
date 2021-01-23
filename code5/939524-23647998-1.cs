    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        IsolatedStorageSettings isoStoreSettings = IsolatedStorageSettings.ApplicationSettings;
        int integerValue;
        string stringValue;
        //Retreive The integer
        if (isoStoreSettings.TryGetValue("IntegerValue", out integerValue))
        {
            Entier.Text = integerValue.ToString();
        }
        //Retreive the string
        if (isoStoreSettings.TryGetValue("StringValue", out stringValue))
        {
            chaine.Text = stringValue;
        }
        isoStoreSettings.Save();
    } 
