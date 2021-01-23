        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(pwdBox.Password)
              somebutton.IsEnabled = false;
            else
              somebutton.IsEnabled = true;
        }
