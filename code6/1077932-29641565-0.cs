    public int SifreGetir(string pEmail) {
        
                SqlConnection con = new SqlConnection("Your connection string here");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand(@"SELECT Sifre FROM Kullanici WITH (NOLOCK) WHERE email=@email",con);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = pEmail;
            
                da.Fill(ds);
                foreach(DataRow dr in ds.Tables[0].Rows)
               {
                    string pass = dr["Sifre"].ToString();
                    int p = Convert.ToInt32(pass);
                    return p;
               }
               con.Close();
            }
