    private void btnclick_Click(object sender, RoutedEventArgs e)
        {
            {
                if (txtuser.Text == "TEST" && psw.Password == "TEST")
                {
                    txtres.Text = "   You are logged in";
                    txtres.Foreground = Brushes.Green;
                    txtres.FontSize = 14;
                    MessageBox.Show("You are logged in");
                    LoginSuccessTab.Visibility = Visibility.Visible;
                }
    
                else
                {
                    txtres.Text = "    You are not logged in";
                    txtres.Foreground = Brushes.Red;
                    txtres.FontSize = 14;
                    MessageBox.Show("You are not logged in");
                    LoginSuccessTab.Visibility = Visibility.Collapsed;
                }
            }
        }
