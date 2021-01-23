    using (SqlConnection cn = new SqlConnection("ConnectionString"))
    {
        using (
            SqlCommand cmd =
                new SqlCommand("select count(*) from studentreg where registrationno = @registrationNumber", cn))
        {
            cmd.Parameters.Add(new SqlParameter("@registrationNumber", SqlDbType.VarChar) {Value = txtrgno.Text});
            //or
            //cmd.Parameters.AddWithValue("@registrationNumber", txtregno.Text);
            cn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar);
            if (count > 0)
            {
                // Already exists
                MessageBox.Show("Registration No. Already Exists Try Another", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtrgno.Text = "";
                txtrgno.Focus();
            }
        }
    }
