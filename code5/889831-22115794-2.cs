    SqlConnection con= new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
    con.Open();
    string db = "declare @a float; set @a = (select MAX(C2) from FJ)+1;instert into FJ(C1, C2, C3) values (@c1 , @a ,@c3)";
    SqlCommand com = new SqlCommand(db, con);
    com.Parameters.AddWithValue("@c1", TextBox1.Text);
    com.Parameters.AddWithValue("@c3", TextBox3.Text);
    com.ExecuteNonQuery();
    con.Close();
