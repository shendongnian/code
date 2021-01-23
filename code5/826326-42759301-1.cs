    public partial class LanguageSettings : PhoneApplicationPage
        {
            public LanguageSettings()
            {
                InitializeComponent();
            }
    
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                
                if (ChangeLanguageCombo.Items.Count == 0)
                {   ChangeLanguageCombo.Items.Add(LocalizationManager.SupportedLanguages.En);
                    ChangeLanguageCombo.Items.Add(LocalizationManager.SupportedLanguages.Bn);
                }
                SelectChoice();
            }
    
           
    
            private void ButtonSaveLang_OnClick(object sender, RoutedEventArgs e)
            {
                //Store the Messagebox result in result variable
                
                MessageBoxResult result = MessageBox.Show("App language will be changed. Do you want to continue?", "Apply Changes", MessageBoxButton.OKCancel);
                
                //check if user clicked on ok
                if (result == MessageBoxResult.OK)
                {
                    
                    var languageComboBox = ChangeLanguageCombo.SelectedItem;
                   
                    LocalizationManager.ChangeAppLanguage(languageComboBox.ToString());
                    //Application.Current.Terminate(); I am commenting out because I don't neede to restart my app anymore.
                }
                else
                {
                    SelectChoice();
                }
            }
    
            private void SelectChoice()
            {
               //Select the saved language
                
                string lang = LocalizationManager.GetCurrentAppLang();
                if(lang == "bn-BD")
                    ChangeLanguageCombo.SelectedItem = ChangeLanguageCombo.Items[1];
                else
                {
                    ChangeLanguageCombo.SelectedItem = ChangeLanguageCombo.Items[0];
                }
            }
        }
 
