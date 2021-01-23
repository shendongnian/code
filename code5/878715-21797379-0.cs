    if ((name.Text == String.Empty) || (name.Text == "Name"))
            {
                MessageBox.Show("Please Enter the name");
                name.Focus();
                return false;
            }
   
