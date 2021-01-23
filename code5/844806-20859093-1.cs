    if (dr.Read())
    {
        if (this.CompareStrings(dr["SCSID"].ToString(), txtUser.Text) &&
            this.CompareStrings(dr["SCSPass"].ToString(), txtPass.Text) &&
            this.CompareStrings(dr["isAdmin"].ToString(), isAdmin))
        {
            MessageBox.Show("Hello " + txtUser.Text, "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var adminf = new Admin(txtUser.Text);
            this.Hide();
            adminf.ShowDialog(); //This line blocks till you close the form
            this.Close(); // <--- NEW LINE
        }
        else if (this.CompareStrings(dr["SCSID"].ToString(), txtUser.Text) &&
            this.CompareStrings(dr["SCSPass"].ToString(), txtPass.Text) &&
            this.CompareStrings(dr["isAdmin"].ToString(), isNotAdmin))
        {
            MessageBox.Show(string.Format("Welcome {0}", txtUser.Text));
            var userf = new UserForm(txtUser.Text);
            this.Hide();
            userf.ShowDialog(); //This line blocks till you close the form
            this.Close(); // <--- NEW LINE
        }
    }
