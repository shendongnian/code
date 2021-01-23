    private void btnUpdateUserData_Click(object sender, RoutedEventArgs e)
    {
       dataGrid.CommitEdit(); // Add this line so that any editing cell gets commit.
       User currentUser = ((Button)sender).DataContext as User;    
       MessageBox.Show("ID: " + currentUser.ID + ", Username: " + 
                        currentUser.Username + ", Password: " + 
                        currentUser.Password + ", Role: " + 
                        currentUser.Role);   
       currentUser.Username = "New Username";
    }
