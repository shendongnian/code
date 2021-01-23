                this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
                private void textBox1_Leave(object sender, EventArgs e)
                {
                SqlConnection scon= new SqlConnection("connection string here");
                SqlCommand cmd = new SqlCommand("seect * from products where ID=@ID",scon);
             
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
              
                scon.Open();
    
                 SqlDataReader sreader=cmd.ExecuteReader();
                 while(sreader.Read())
                 {
                 //do whatever you want with data
                 }
                scon.Close();
                }
