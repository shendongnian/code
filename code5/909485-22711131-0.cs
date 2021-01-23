    private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS; AttachDbFilename=C:\Users\John\Documents\Visual Studio 2010\Projects\Shop\Shop\shop.mdf; Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection myDbconnection = new SqlConnection(connectionString);
            myDbconnection.Open();
            sqlQRY = "Select prix from fleurs where nom='"+flori.SelectedValue+"'";
            SqlCommand cmd = new SqlCommand(sqlQRY, myDbconnection);
            
            var value = (String)cmd.ExecuteScalar();
            if (!string.IsNullOrEmpty(value))
            {
                label6.Text = value;
    
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
