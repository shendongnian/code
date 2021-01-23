    string cleaned = richTextBox1.Text.Trim();
    string st = "INSERT INTO TABLE1(word) VALUES(@Word)";
    SqlConnection con = new SqlConnection("Data Source=ZAZIKHAN\\SQLEXPRESS;Initial Catalog=mis;Integrated Security=True");
    con.Open();
    SqlCommand cmd = new SqlCommand(st, con);
    SqlParameter param = new SqlParameter("@Word", SqlDbType.NChar);
    param.Value = "A_"+cleaned;
    cmd.Parameters.Add(param);
