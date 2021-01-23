        private void passwordBox_PW_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            PasswordBox pwdBox = (PasswordBox)sender;
            Room r = pwdBox.DataContext as Room;
            r.Password = pwdBox.Password;
        }       
