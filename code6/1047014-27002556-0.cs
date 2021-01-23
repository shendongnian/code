        private void populateEmail(object sender, System.EventArgs e)
        {
            string FirstName = txtBoxFirstName.Text;
            string LastName = txtBoxLastName.Text;
            txtBoxEmail.Text = FirstName + "." + LastName + "@organization.org";
        }
