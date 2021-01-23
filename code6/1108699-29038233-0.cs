      SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFilename=C:\Users\Gustavo\Documents\Visual Studio 2013\Projects\hour\hour\Database1.mdf");
            try
            {
                string query = "INSERT INTO [Table] (name, time) VALUES ('test',1)";
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
