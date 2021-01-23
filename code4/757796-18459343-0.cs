    private bool Login(string supportName, string password)
    {
       if(string.IsNullOrEmpty(supportName) || string.IsNullOrEmpty(password))
       {
          throw new ArgumentException();
       }
    
       using(var connection = Helper.getconnection())
       using(var command = connection.CreateCommand())
       {
          conmmand.CommandText = "SELECT 1 FROM Logins WHERE SupportName=@SupportName AND Password=@Password";
          command.Parameters.AddWithValue("@SupportName", supportName);
          command.Parameters.AddWithValue("@Password", password);
    
          return command.ExecuteScalar() != null;
       }
    }
    
    private void ShowSupportForm()
    {
       var supportName = txtSupportName.Text;
       var password = txtPassword.Text;
    
       if (string.IsNullOrEmpty(supportName))
       {
          MessageBox.Show("Please enter a value to Support Name!");
          txtSupportName.Focus();
          return;
       }
    
       if (string.IsNullOrEmpty(password))
       {
          MessageBox.Show("Please enter a value to Passwod!");
          txtPassword.Focus();
          return;
       }
    
       if(Login(supportName, password))
       {
          using(var form = new Support())
          {
             form.ShowDialog(this);
          }
       }
       else
       {
          MessageBox.Show("SupportName and password are invalid");
       }
    }
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        ShowSupportForm();
    }
