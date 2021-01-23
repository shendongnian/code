     this.ListContactsTapCommand = new RelayCommand<LongListSelector>(param => ShowContactInformation(param), param => param.SelectedItem != null);
     private void ShowContactInformation(LongListSelector c)
            {
    
                ServiceLocator.Current.GetInstance<ContactInfoViewModel>().ContactInfo = c.SelectedItem as Contact;
                _navigationService.NavigateTo(new Uri(ViewModelLocator.ContactInfoPage, UriKind.Relative));
                c.SelectedItem = null;
    
            }
