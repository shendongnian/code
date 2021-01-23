    private void btnUpdateUserData_Click(object sender, RoutedEventArgs e)
    {
       dataGrid.CommitEdit(); // Add this line so that any editing cell gets commit.
       User currentUser = dataGrid.SelectedItem as User;
       // currentUser will be null in case SelectedItem is null.
       if(currentUser != null)
       {
          MessageBox.Show("ID: " + currentUser.ID + ", Username: " + 
                           currentUser.Username + ", Password: " + 
                           currentUser.Password + ", Rolle: " + 
                           currentUser.Role);
    
          currentUser.Username = "New Username";
       }
    }
