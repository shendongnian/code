    private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        Person person = (Person)DataContext;
        e.CanExecute = !string.IsNullOrEmpty(person.Name) && 
            !string.IsNullOrEmpty(person.Password) && 
            !string.IsNullOrEmpty(txtConfirmPass.Text) && 
            txtConfirmPass.Text == person.Password;
    }
