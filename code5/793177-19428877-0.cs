    private void Delete_Click(object sender, RoutedEventArgs e)
    {
               
        if (dgsample.SelectedItem != null)
        {
            var usr = dgsample.SelectedItem as User;
    
            if (usr != null)
            {
                var deleteMe = Users.FirstOrDefault(us => us.Id == usr.Id);
                if (deleteMe != null)
                {
                    Users.Remove(deleteMe);
                }
                else
                {
                    MessageBox.Show(string.Format("User with Id {0} not found to delete", deleteMe.Id);
                }
            }
            else
            {
                MessageBox.Show("Unknown type in datagrid")
            }
        }
        else
        {
            MessageBox.Show("No user selected to delete");
        }
    
    }
