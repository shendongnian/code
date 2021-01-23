     if (txtpassword1.Text == "" || txtpassword2.Text == "")
            {
                MessageBox.Show("Please enter values");
                txtpassword1.Focus();
                return;
            }
            if (txtpassword1.Text != txtpassword2.Text)
            {
                MessageBox.Show("Password not matching");
                txtpassword2.Focus();
                return;
            }
