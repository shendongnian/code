     public Button CreateButton() 
            {
                Button b = new Button();
                Application.Current.Resources.Source = new Uri("/ResourceDictionary.xaml", UriKind.Relative);
                b.Style = (Style)Application.Current.Resources["MainScreenButtonStyle"];
                return b;
            }
