    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var si = settings_language_cb.SelectedItem as LanguageCode;
        if(si != null) 
            changeLang(si.CodeName);  // changeLang("de-DE");
    }
