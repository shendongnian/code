    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        IsolatedStorageSettings isoStoreSettings = IsolatedStorageSettings.ApplicationSettings;
        int integerValue;
        int.TryParse(Entier.Text, out integerValue);
        //store the integer
        isoStoreSettings["IntegerValue"] = integerValue;
        //store the string
        isoStoreSettings["StringValue"] = chaine.Text;
    }
