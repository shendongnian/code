       DataSet ds = new DataSet();
       SqlDataAdapter sda = new SqlDataAdapter("select * from Kullanici WHERE ....");
       sda.Fill(ds);
       if (ds.Tables[0].Rows.Count == 0)
       {
           MessageBox.Show("Geçersiz Kullanıcı.", "Chat Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
       else if(ds.Tables[0].Rows.Count == 1)
       {
               MessageBox.Show("Hoşgeldiniz.", "Chat Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
       }
