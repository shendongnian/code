    private void btnSubmit_Click(object sender, RoutedEventArgs e)
    {
        string id = tbxUsername.Text;
        string password = tbxPassword.Text;
        using (DataClasses1DataContext db = new DataClasses1DataContext())
        {
            if(IsValidLogin(id, password))
            {
                MessageBox.Show("Login Successful!");
            }
            else
            {
                MessageBox.Show("Login unsuccessful, no such user!");
            }
        }
    }
