    private void button1_Click(object sender, EventArgs e)
    {
       if ((textBox1.Text == "") || (textBox2.Text == ""))
       {
           MessageBox.Show("Bu alanları boş bırakamazsınız.", "Chat Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
           return;
       }
       string cmdText = @"select COUNT(*) from Kullanici 
                          WHERE kul_adi=@user AND sifre=@pwd";
       using(SqlConnection conn = new SqlConnection("Server=CAGDAS-LAPTOP;Database=chat;Trusted_Connection=true;"))
       using(SqlCommand cmd = new SqlCommand(cmdText, conn))
       {
           conn.Open();
           cmd.Parameters.AddWithValue("@user", textBox1.Text);
           cmd.Parameters.AddWithValue("@pwd", textBox2.Text);
           int userCount = Convert.ToInt32(cmd.ExecuteScalar());
           if (userCount == 0)
           {
               MessageBox.Show("Geçersiz Kullanıcı.", "Chat Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else if(userCount == 1)
           {
               MessageBox.Show("Hoşgeldiniz.", "Chat Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
       }
    }
