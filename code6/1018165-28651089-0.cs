    private void Page_Settings_LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
	  if (oldLang != (PageSettings_Language_cb.SelectedItem as ComboboxItem).Value.ToString())
	  {
		try
		{
			changeLang((PageSettings_Language_cb.SelectedItem as ComboboxItem).Value.ToString());
			ShowRestartMessageBox();
		}
		catch (Exception)
		{ }
	  }
    }
