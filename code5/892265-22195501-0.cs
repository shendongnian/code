            string username = "Tim";
            string password = "Hennings";
			if(this.txtUsername.Text != username)
			{
			    MessageBox.Show("Wrong Username please try again");
                txtUsername.Focus();
			}else if(this.txtPassword.Text != password)
			{
			    MessageBox.Show("Wrong Password please try again");
                txtPassword.Focus();
			}else
			{
				MessageBox.Show("Log in successful");
			}
