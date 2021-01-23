    con = new SqlConnection("Data Source=DELL-PC;Initial Catalog=sashi;Integrated Security=True");
    con.Open();
    SqlCommand sc = new SqlCommand("INSERT INTO Login VALUES(@uid,@pass,@qun,@ANS)", con);
    
    sc.Parameters.Add(new SqlParameter("@uid", textBoxUID.Text));
    sc.Parameters.Add(new SqlParameter("@pass", textBoxPWD.Text));
    sc.Parameters.Add(new SqlParameter("@qun", comboBoxQUN.Text));
    sc.Parameters.Add(new SqlParameter("@ANS", textBoxANS.Text));
