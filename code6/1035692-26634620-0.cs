    private void Login_Button_Click(object sender, RoutedEventArgs e)
    {
        if (CheckFields() && WritePerforceSettingsXml(rewriteSettingsCheckbox.IsChecked.Value))
        {
            Dictionary<string, string> installerToUpdateList = new Dictionary<string, string>();
            if (GetUpdateListFilesFromXml(ref installerToUpdateList))
            {         
                //some code
            }
        }
    }
