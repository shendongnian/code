    private void button1_Click(object sender, EventArgs e)
    {
        using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\abdul samad\documents\visual studio 2013\Projects\newpro\newpro\Database1.mdf;Integrated Security=True"))
        {
            try
            {
             
                using (var cmd = new SqlCommand("INSERT INTO registor (Name, FullName, Password, Email, Gander) VALUES (@Name,@Fullname,@Password,@Email, @Gander)"))
                {
                    
                    cmd.Connection = con;   
                    cmd.Parameters.Add("@Name", txtfname.Text);
                    cmd.Parameters.Add("@Fullname", txtfname.Text);
                    cmd.Parameters.Add("@Password", txtpass.Text);
                    cmd.Parameters.Add("@Email", txtemail.Text);
                    cmd.Parameters.Add("@Gander", comboBox1.GetItemText(comboBox1.SelectedItem));
                    
                    con.Open()
                    if(cmd.ExecuteNonQuery() > 0) 
                    {
                       MessageBox.Show("Record inserted"); 
                    }
                    else
                    {
                       MessageBox.Show("Record failed");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during insert: " + e.Message);
            }
        }
    }
