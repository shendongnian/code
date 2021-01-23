    protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project"].ConnectionString.ToString());
            
            string arun = "UPDATE [RECEIVE] SET [RDDF2]=@RDFF2 WHERE [OIESN]=@SRT";
            string SR2 = TextBox1.Text;
            int SR = int.Parse(TextBox1.Text);
            string SR1 = TextBox9.Text;
    
            using (SqlCommand SqlCmd = new SqlCommand(arun, conn))
            {
                conn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@SRT", SqlDbType.Int).Value = SR;
                cmd.Parameters.Add("@RDFF2", SqlDbType.VarChar).Value = SR1;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
