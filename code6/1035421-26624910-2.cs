    using (var con = new SqlConnection("Data Source=DELL-PC;Initial Catalog=sashi;Integrated Security=True")) 
    {
        con.Open(); 
        using(var sc = connection.CreateCommand()) 
        { 
            sc.CommandText = "INSERT INTO Login VALUES(@uid,@pass,@qun,@ans)";  
    
            sc.Parameters.Add(new SqlParameter("@uid", textBoxUID.Text));
            sc.Parameters.Add(new SqlParameter("@pass", textBoxPWD.Text));
            sc.Parameters.Add(new SqlParameter("@qun", comboBoxQUN.Text));
            sc.Parameters.Add(new SqlParameter("@ans", textBoxANS.Text));;  
    
            sc.ExecuteNonQuery(); 
        } 
    }
