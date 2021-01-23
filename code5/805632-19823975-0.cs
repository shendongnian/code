    private async void LoginButton_Click(object sender, RoutedEventArgs e)
            {
                var loginTask = userRepository.LoginAsync(LoginTextBox.Text, PasswordTextBox.Password);
                controller.DisplayPageLoader();
                DbUser loginResult = await loginTask;
                if (loginResult != null)
                {
                    controller.DisplayPageNewMeal();
                    controller.SetLoggedUser(loginResult);
                }
                else
                {
                    MessageBox.Show("Błędny login lub hasło. Spróbuj ponownie.");
                    controller.DisplayPageLogin();
                }
            }
