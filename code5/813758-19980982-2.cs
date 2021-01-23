            if (Imetxt.Text == "")
            {
                MessageBox.Show("Please enter a valid user name!");
                Imetxt.Focus();
                return;
            }
            else if (Passtxt.Text == "")
            {
                MessageBox.Show("Please enter a valid password!");
                Passtxt.Focus();
                return;
            }
