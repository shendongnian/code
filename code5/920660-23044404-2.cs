    private void btnUpdateUserData_Click(object sender, RoutedEventArgs e)
    {
       User currentUser = ((Button)sender).DataContext as User;    
       MessageBox.Show("ID: " + currentUser.ID + ", Username: " + 
                        currentUser.Username + ", Password: " + 
                        currentUser.Password + ", Role: " + 
                        currentUser.Role);   
       currentUser.Username = "New Username";
    }
